using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class LogUdpModule
{
    private static LogUdpModule sLogUdpModule;

    public static void Open()
    {
        if (sLogUdpModule == null)
        {
            sLogUdpModule = new LogUdpModule();
        }
    }

    public static void Close()
    {
        if (sLogUdpModule != null)
        {
            sLogUdpModule.Dispose();
            sLogUdpModule = null;
        }
    }

    /// <summary>
    /// 本机UDP
    /// </summary>
    private UdpClient m_UdpClient;

    /// <summary>
    /// 目标地址
    /// </summary>
    private IPEndPoint m_EndPoint;

    /// <summary>
    /// 是否连接成功
    /// </summary>
    private bool m_Connected;

    /// <summary>
    /// 暂存还没连上的时候信息
    /// </summary>
    private readonly ConcurrentQueue<string> m_ConcurrentUdp;

    /// <summary>
    /// 字符串拼接
    /// </summary>
    private readonly StringBuilder m_StringBuilder;

    private LogUdpModule()
    {
        m_StringBuilder = new StringBuilder();
        m_ConcurrentUdp = new ConcurrentQueue<string>();
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, 22233);
        m_UdpClient = new UdpClient(ep);
        m_UdpClient.BeginReceive(ReceiveCallback, this);
        Application.logMessageReceivedThreaded += OnLogMessageReceivedThreaded;
    }

    private void Dispose()
    {
        m_UdpClient.Close();
        m_UdpClient = null;
        Application.logMessageReceivedThreaded -= OnLogMessageReceivedThreaded;
    }

    private void OnLogMessageReceivedThreaded(string logString, string stackTrace, LogType type)
    {
        m_StringBuilder.Length = 0;
        if (type == LogType.Log)
        {
            m_StringBuilder.Append("LogStart1----");
        }
        else if (type == LogType.Warning)
        {
            m_StringBuilder.Append("LogStart2----");
        }
        else
        {
            m_StringBuilder.Append("LogStart3----");
        }
        m_StringBuilder.Append(logString);
        m_StringBuilder.Append('\n');
        m_StringBuilder.Append(stackTrace);
        logString = m_StringBuilder.ToString();

        if (m_Connected)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes(logString);
            m_UdpClient.Send(sendBytes, sendBytes.Length, m_EndPoint);
        }
        else
        {
            m_ConcurrentUdp.Enqueue(logString);
        }
    }

    private void OnReceiveCallback(string receiveString)
    {
        if (receiveString == "ack")
        {
            while (m_ConcurrentUdp.Count > 0 && m_ConcurrentUdp.TryDequeue(out var msg))
            {
                byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
                m_UdpClient.Send(sendBytes, sendBytes.Length, m_EndPoint);
            }

            m_Connected = true;
        }
        else if (m_Connected && receiveString.StartsWith("pm:", StringComparison.Ordinal))
        {
            
        }

        m_UdpClient.BeginReceive(ReceiveCallback, this);
    }

    public static void ReceiveCallback(IAsyncResult ar)
    {
        LogUdpModule l = (LogUdpModule)(ar.AsyncState);

        if (l.m_UdpClient == null)
        {
            return;
        }

        try
        {
            byte[] receiveBytes = l.m_UdpClient.EndReceive(ar, ref l.m_EndPoint);
            string receiveString = Encoding.UTF8.GetString(receiveBytes);
            l.OnReceiveCallback(receiveString);
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}
