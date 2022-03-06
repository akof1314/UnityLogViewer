using System;
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
        private System.Timers.Timer timer;

        public NetClient(DocLogFile page)
        {
            pageForm = page;
            udpClient = new UdpClient(22234);
            udpClient.BeginReceive(ReceiveCallback, this);
        }

        public void ClearObjects()
        {
            if (timer != null)
            {
                timer.Stop();
            }
            udpClient.Close();
            udpClient = null;
        }

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
            if (timer == null)
            {
                timer = new System.Timers.Timer(2000);
                timer.Elapsed += TimerOnElapsed;
            }
            else
            {
                timer.Stop();
            }
            timer.Start();

            // 启动的时候，每秒去发送握手到对方，直到收到对方的任意消息
            SendAckToRemoteInter();
        }

        private void SendAckToRemoteInter()
        {
            Console.WriteLine("send ack");
            byte[] sendBytes = Encoding.UTF8.GetBytes("ack");
            int sendCount = udpClient.Send(sendBytes, sendBytes.Length, endPoint);
            Console.WriteLine("send ack ok" + sendCount);
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            SendAckToRemoteInter();
        }

        public static void ReceiveCallback(IAsyncResult ar)
        {
            NetClient n = (NetClient) ar.AsyncState;

            if (n.udpClient == null || n.udpClient.Client == null)
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
                    if (n.timer != null && n.timer.Enabled)
                    {
                        n.timer.Stop();
                    }

                    n.pageForm.Log.WriteUdpLine(receiveBytes);
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