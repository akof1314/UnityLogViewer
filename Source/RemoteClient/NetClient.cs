using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;

namespace LogViewer
{
    public class NetClient
    {
        public DocLogFile pageForm { get; private set; }

        /// <summary>
        /// 暂停接收日志
        /// </summary>
        public bool IsPausing { get; set; }

        /// <summary>
        /// upd客户端
        /// </summary>
        private UdpClient udpClient;

        /// <summary>
        /// 目标地址
        /// </summary>
        private IPEndPoint endPoint;

        /// <summary>
        /// 收到的地址
        /// </summary>
        private IPEndPoint recvPoint;

        /// <summary>
        /// 定时器去第一次握手远程，直接收到对方的任意消息
        /// </summary>
        private System.Timers.Timer ackTimer;

        /// <summary>
        /// 刷新写入的定时器
        /// </summary>
        private Timer tickTimer;

        internal class UdpLine : AdbClient.BaseLine
        {
            #region Member Variables/Properties
            public int CharCount { get; set; } = 0;
            public byte[] ByteArray { get; set; }

            // 注意这里返回的包含tag
            public override string GetLineText()
            {
                var str = Encoding.UTF8.GetString(ByteArray, 13, CharCount);
                return str;
            }
            #endregion
        }

        /// <summary>
        /// 缓存
        /// </summary>
        private List<UdpLine> lines;

        /// <summary>
        /// 锁对象
        /// </summary>
        private readonly object balanceLock = new object();

        public NetClient(DocLogFile page)
        {
            pageForm = page;
            lines = new List<UdpLine>();
            udpClient = new UdpClient(22234);
            udpClient.BeginReceive(ReceiveCallback, this);
            tickTimer = new Timer(30);
            tickTimer.Elapsed += TickTimerOnElapsed;
            tickTimer.Start();
        }

        public void ClearObjects()
        {
            if (ackTimer != null)
            {
                ackTimer.Stop();
            }
            if (tickTimer != null)
            {
                tickTimer.Stop();
            }
            udpClient.Close();
            udpClient = null;
        }

        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="msg"></param>
        public void SendShellMsg(string msg)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes("pm:" + msg);
            int sendCount = udpClient.Send(sendBytes, sendBytes.Length, endPoint);
            Console.WriteLine("send pm ok" + sendCount);
        }

        /// <summary>
        /// 设置目标地址，会自动进行连接
        /// </summary>
        /// <param name="ipStr"></param>
        /// <param name="ipPort"></param>
        /// <returns></returns>
        public bool SetEndPoint(string ipStr, int ipPort)
        {
            if (IPAddress.TryParse(ipStr, out var ipAddress))
            {
                endPoint = new IPEndPoint(ipAddress, ipPort);
                SendAckToRemote();
                return true;
            }
            else
            {
                Global.ShowErrorDialog("非有效的IP地址");
            }

            return false;
        }

        private void SendAckToRemote()
        {
            if (ackTimer == null)
            {
                ackTimer = new System.Timers.Timer(2000);
                ackTimer.Elapsed += AckTimerOnElapsed;
            }
            else
            {
                ackTimer.Stop();
            }
            ackTimer.Start();

            // 启动的时候，每秒去发送握手到对方，直到收到对方的任意消息
            SendAckToRemoteInter();
        }

        private void SendAckToRemoteInter()
        {
            try
            {
                byte[] sendBytes = Encoding.UTF8.GetBytes("ack");
                int sendCount = udpClient.Send(sendBytes, sendBytes.Length, endPoint);
                Console.WriteLine("send ack ok" + sendCount);

                pageForm.BeginInvoke(new Action(() =>
                {
                    pageForm.TipConnectText($"尝试连接目标：{endPoint}  \t 发送请求时间：{DateTime.Now}");
                }));
            }
            catch (Exception e)
            {
                if (ackTimer != null)
                {
                    ackTimer.Stop();
                }
                pageForm.BeginInvoke(new Action(() => { Global.ShowErrorDialog("尝试连接目标异常，原因：" + e.Message); }));
            }
        }

        private void AckTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            SendAckToRemoteInter();
        }

        private void TickTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            lock (balanceLock)
            {
                if (lines.Count > 0)
                {
                    pageForm.Log.WriteUdpLine(lines);
                    lines.Clear();
                }
            }
        }

        public static void ReceiveCallback(IAsyncResult ar)
        {
            NetClient n = (NetClient)ar.AsyncState;

            if (n.udpClient?.Client == null)
            {
                return;
            }

            try
            {
                byte[] receiveBytes = n.udpClient.EndReceive(ar, ref n.recvPoint);
                //string receiveString = Encoding.UTF8.GetString(receiveBytes);

                // 判断目标地址
                if (Equals(n.recvPoint, n.endPoint))
                {
                    if (n.ackTimer != null && n.ackTimer.Enabled)
                    {
                        n.ackTimer.Stop();

                        n.pageForm.BeginInvoke(new Action(n.pageForm.ConnectUdpDevice));
                    }

                    if (!n.IsPausing)
                    {
                        // 认为是ConsoleTiny日志
                        if (receiveBytes.Length > 13)
                        {
                            Global.LogType logType = Global.LogType.Info;
                            // ConsoleTiny 的解析
                            if (receiveBytes.Length > 13 && receiveBytes[9] == '-' && receiveBytes[7] == 't')
                            {
                                if (receiveBytes[8] == '3')
                                {
                                    logType = Global.LogType.Error;
                                }
                                else if (receiveBytes[8] == '2')
                                {
                                    logType = Global.LogType.Warning;
                                }
                                else if (receiveBytes[8] == '1')
                                {
                                    logType = Global.LogType.Info;
                                }
                            }

                            // 不管log是不是多行，都只把第一行当做信息
                            // 转成字节，找到\n的位置，不能用字符串直接找，会有编码位置不同的问题
                            var charCount = 0;
                            for (int i = 0; i < receiveBytes.Length; i++)
                            {
                                if (receiveBytes[i] == 10)
                                {
                                    charCount = i;
                                    break;
                                }
                            }

                            var newLine = new UdpLine { CharCount = charCount, ByteArray = receiveBytes, LogType = (int)logType };
                            
                            lock (n.balanceLock)
                            {
                                // 定时器去写入GUI，否则每条都刷新，导致要刷很久
                                n.lines.Add(newLine);
                            }
                        }
                    }
                }

                //Console.WriteLine(receiveString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (n.udpClient != null)
            {
                n.udpClient.BeginReceive(ReceiveCallback, n);
            }
        }
    }
}