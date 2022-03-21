using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using woanware;

namespace LogViewer
{
    public class AdbClient
    {
        public DocLogFile pageForm { get; private set; }

        /// <summary>
        /// 正在忙碌，不允许其他操作
        /// </summary>
        public bool IsBusying { get; private set; }

        /// <summary>
        /// 设备ID列表
        /// </summary>
        public List<string> DevicesIdList { get; private set; }

        /// <summary>
        /// 设备名称列表
        /// </summary>
        public List<string> DevicesNameList { get; private set; }

        /// <summary>
        /// 暂停接收日志
        /// </summary>
        public bool IsPausing { get; set; }

        internal class BaseLine
        {
            #region Member Variables/Properties
            public int LogType { get; set; } = 0;
            public bool IsCrLine { get; set; } = false;
            public bool IsTerms { get; set; } = true;
            public bool IsCurSearch { get; set; }

            public virtual string GetLineText()
            {
                return String.Empty;
            }
            #endregion
        }
        internal class AdbLine : BaseLine
        {
            #region Member Variables/Properties
            public string LineText { get; set; } = String.Empty;
            public string StackTraceText { get; set; } = String.Empty;

            public override string GetLineText()
            {
                return LineText;
            }
            #endregion
        }
        internal List<AdbLine> Lines { get; private set; }

        private Timer tickTimer;

        /// <summary>
        /// 采集日志的进程
        /// </summary>
        private Process adbLogProcess;

        /// <summary>
        /// 当然操作的设备索引
        /// </summary>
        private int curDeviceIdIndex;

        /// <summary>
        /// adb的路径
        /// </summary>
        private string adbPath;

        /// <summary>
        /// 锁对象
        /// </summary>
        private readonly object balanceLock = new object();

        public AdbClient(DocLogFile page)
        {
            pageForm = page;
            FindAdbPath();
            DevicesIdList = new List<string>();
            DevicesNameList = new List<string>();
            Lines = new List<AdbLine>();
            tickTimer = new Timer(30);
            tickTimer.Elapsed += TimerOnElapsed;
            tickTimer.Start();
        }

        public void ClearObjects()
        {
            if (tickTimer != null)
            {
                tickTimer.Stop();
            }
            DisconnectDeviceInter();
        }

        private void FindAdbPath()
        {
            const string kAdbExe = "adb.exe";
            var paths = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
            if (!string.IsNullOrEmpty(paths))
            {
                var files = paths.Split(';');
                foreach (var path in files)
                {
                    if (!String.IsNullOrEmpty(path) && File.Exists(System.IO.Path.Combine(path, kAdbExe)))
                    {
                        adbPath = kAdbExe;
                        return;
                    }
                }
            }
            adbPath = System.IO.Path.Combine(Misc.GetApplicationDirectory(), kAdbExe);
        }

        private string GetPath()
        {
            return adbPath;
        }

        private string GetScreenCapPath()
        {
            return System.IO.Path.Combine(Misc.GetApplicationDirectory(), "ADBScreenCap");
        }

        public void GetDevices()
        {
            GetDevicesInter();
        }

        public void ChooseDevice(int index)
        {
            curDeviceIdIndex = index;
            ChooseDeviceInter(DevicesIdList[index]);
        }

        public void GetScreenCap()
        {
            GetScreenCapInter(DevicesIdList[curDeviceIdIndex]);
        }

        public void SetConnect(string ipPort)
        {
            SetConnectInter(ipPort);
        }

        private void GetDevicesInter()
        {
            if (IsBusying)
            {
                return;
            }
            IsBusying = true;
            DevicesIdList.Clear();
            DevicesNameList.Clear();

            var adbProcess = new Process
            {
                StartInfo = {
                FileName = GetPath(),
                Arguments = "devices -l",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8
                },
            };

            var startDevice = false;
            adbProcess.OutputDataReceived += (sender, e) =>
            {
                var line = e.Data;
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }
                Console.WriteLine(line);

                if (startDevice)
                {
                    var idx = line.IndexOf("device", StringComparison.Ordinal);
                    if (idx > -1)
                    {
                        var deviceId = line.Substring(0, idx).TrimEnd();
                        DevicesIdList.Add(deviceId);

                        string deviceProduct = GetStrMid(line, "model:", " ");
                        if (!string.IsNullOrEmpty(deviceProduct))
                        {
                            deviceId += "-";
                            deviceId += deviceProduct;

                            deviceProduct = GetStrMid(line, "device:", " ");
                            if (!string.IsNullOrEmpty(deviceProduct))
                            {
                                deviceId += "-";
                                deviceId += deviceProduct;
                            }
                        }
                        DevicesNameList.Add(deviceId);
                        Console.WriteLine(deviceId);
                    }
                }
                else if (line == "List of devices attached")
                {
                    startDevice = true;
                }
            };

            Task.Run(() =>
            {
                try
                {
                    adbProcess.Start();
                    adbProcess.BeginOutputReadLine();
                    adbProcess.WaitForExit(5000);
                    if (!adbProcess.HasExited)
                    {
                        adbProcess.Kill();
                    }

                    adbProcess.Close();
                    adbProcess.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Global.ShowErrorDialog(e.Message);
                }

                IsBusying = false;
                pageForm.BeginInvoke(new Action(() =>
                {
                    pageForm.RefreshAdbDevicesList();
                }));
            });
        }

        private void SetConnectInter(string ipPort)
        {
            if (IsBusying)
            {
                return;
            }
            IsBusying = true;

            var adbProcess = new Process
            {
                StartInfo = {
                FileName = GetPath(),
                Arguments = "connect " + ipPort,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8
                },
            };

            adbProcess.OutputDataReceived += (sender, e) =>
            {
                var line = e.Data;
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }
                Console.WriteLine(line);
                pageForm.BeginInvoke(new Action(() =>
                {
                    pageForm.TipConnectText(line);
                }));
            };
            pageForm.TipConnectText("尝试 connect " + ipPort);

            Task.Run(() =>
            {
                try
                {
                    adbProcess.Start();
                    adbProcess.BeginOutputReadLine();
                    adbProcess.WaitForExit(5000);
                    if (!adbProcess.HasExited)
                    {
                        adbProcess.Kill();
                    }

                    adbProcess.Close();
                    adbProcess.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Global.ShowErrorDialog(e.Message);
                }

                IsBusying = false;
            });
        }

        private void GetScreenCapInter(string deviceId)
        {
            if (IsBusying)
            {
                return;
            }
            IsBusying = true;

            var adbProcess = new Process
            {
                StartInfo = {
                FileName = GetPath(),
                Arguments = "-s " + deviceId + " shell screencap -p /sdcard/unitylogviewer-screencap.png",
                CreateNoWindow = true,
                UseShellExecute = false,
                },
            };

            Task.Run(() =>
            {
                try
                {
                    adbProcess.Start();
                    adbProcess.WaitForExit(5000);
                    if (!adbProcess.HasExited)
                    {
                        adbProcess.Kill();
                    }
                    else
                    {
                        var destDir = GetScreenCapPath();
                        if (!System.IO.Directory.Exists(destDir))
                        {
                            System.IO.Directory.CreateDirectory(destDir);
                        }

                        var destPath = string.Format("{0:yyyy-MM-dd_HH-mm-ss-fff}.png", DateTime.Now);
                        destPath = System.IO.Path.Combine(destDir, destPath);
                        adbProcess.StartInfo.Arguments = "-s " + deviceId + " pull /sdcard/unitylogviewer-screencap.png \"" + destPath + "\"";

                        adbProcess.Start();
                        adbProcess.WaitForExit(5000);
                        if (!adbProcess.HasExited)
                        {
                            adbProcess.Kill();
                        }

                        if (System.IO.File.Exists(destPath))
                        {
                            Process.Start(destPath);
                        }
                    }

                    adbProcess.Close();
                    adbProcess.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Global.ShowErrorDialog(e.Message);
                }

                IsBusying = false;
            });
        }

        private void ChooseDeviceInter(string deviceId)
        {
            DisconnectDeviceInter();
            var adbProcess = new Process
            {
                StartInfo = {
                FileName = GetPath(),
                Arguments = "-s " + deviceId + " logcat -v brief -s \"Unity\"",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8
                },
            };

            bool isConnectOk = false;
            adbProcess.OutputDataReceived += (sender, e) =>
            {
                var line = e.Data;
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }
                //Console.WriteLine(line);

                if (!isConnectOk)
                {
                    if (line.StartsWith("--------- beginning of", StringComparison.Ordinal))
                    {
                        isConnectOk = true;
                        pageForm.BeginInvoke(new Action(pageForm.ConnectAdbDevice));
                        return;
                    }
                }

                if (IsPausing)
                {
                    return;
                }
                ParseLog2(line);
            };

            adbProcess.ErrorDataReceived += (sender, e) =>
            {
                var line = e.Data;
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }
                Console.WriteLine(line);
            };

            Task.Run(() =>
            {
                try
                {
                    adbProcess.Start();
                    adbProcess.BeginOutputReadLine();
                    adbProcess.BeginErrorReadLine();
                    adbLogProcess = adbProcess;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Global.ShowErrorDialog(e.Message);
                }
            });
        }

        private void DisconnectDeviceInter()
        {
            if (adbLogProcess != null)
            {
                if (!adbLogProcess.HasExited)
                {
                    adbLogProcess.Kill();
                }

                if (adbLogProcess != null)
                {
                    adbLogProcess.Close();
                    adbLogProcess.Dispose();
                    adbLogProcess = null;
                }
            }
        }

        private string GetStrMid(string text, string left, string right)
        {
            var idx = text.IndexOf(left, StringComparison.Ordinal);
            if (idx < 0)
            {
                return string.Empty;
            }

            var startIdx = idx + left.Length;
            idx = text.IndexOf(right, startIdx, StringComparison.Ordinal);
            if (idx < 0)
            {
                return string.Empty;
            }

            return text.Substring(startIdx, idx - startIdx);
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (adbLogProcess == null)
            {
                return;
            }

            // 设备失联，进程自动退出
            if (adbLogProcess.HasExited)
            {
                Console.WriteLine("adbLogProcess.HasExited");
                DisconnectDeviceInter();

                Lines.Clear();
                pageForm.BeginInvoke(new Action(() => pageForm.DisconnectAdbDevice()));
                return;
            }

            lock (balanceLock)
            {
                if (Lines.Count > 0)
                {
                    var lastLine = Lines[Lines.Count - 1];

                    // 如果最后一行还没有结束，先移除再添加
                    if (!lastLine.IsCrLine)
                    {
                        Lines.RemoveAt(Lines.Count - 1);
                    }
                    else
                    {
                        lastLine = null;
                    }

                    pageForm.Log.WriteAdbLines(Lines);
                    Lines.Clear();

                    if (lastLine != null)
                    {
                        Lines.Add(lastLine);
                    }
                }
            }
        }

        private void ParseLog2(string line)
        {
            if (line.StartsWith("I/Unity", StringComparison.Ordinal))
            {
                ParseLog3(line, 11);
            }
            else if (line.StartsWith("W/Unity", StringComparison.Ordinal))
            {
                ParseLog3(line, 21);
            }
            else if (line.StartsWith("D/Unity", StringComparison.Ordinal))
            {
                ParseLog3(line, 12);
            }
            else if (line.StartsWith("V/Unity", StringComparison.Ordinal))
            {
                ParseLog3(line, 13);
            }
            else if (line.StartsWith("E/Unity", StringComparison.Ordinal))
            {
                ParseLog3(line, 41);
            }
            else if (line.StartsWith("F/Unity", StringComparison.Ordinal))
            {
                ParseLog3(line, 42);
            }
        }

        private void ParseLog3(string line, int logType)
        {
            var idx = line.IndexOf(':');
            if (idx > -1)
            {
                lock (balanceLock)
                {
                    ParseLog(line.Substring(idx + 2), logType);
                }
            }
        }

        private void ParseLog(string line, int logType)
        {
            // 长度为空，代表一个日志结束
            if (line.Length == 0)
            {
                if (Lines.Count > 0)
                {
                    Lines[Lines.Count - 1].IsCrLine = true;
                }
                return;
            }

            bool isNew = true;
            if (Lines.Count > 0)
            {
                isNew = Lines[Lines.Count - 1].IsCrLine;

                if (!isNew && Lines[Lines.Count - 1].LogType != logType)
                {
                    Lines[Lines.Count - 1].IsCrLine = true;
                    isNew = true;
                }
            }

            if (isNew)
            {
                var newLine = new AdbLine { LineText = line + "\r\n", LogType = logType };
                Lines.Add(newLine);

                // 如果的D/V的话，不需要解析堆栈，直接显示
                if (logType == 12 || logType == 13)
                {
                    newLine.IsCrLine = true;
                }
            }
            else if (Lines.Count > 0)
            {
                Lines[Lines.Count - 1].StackTraceText += line + "\r\n";
            }
        }
    }
}