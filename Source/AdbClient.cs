using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using DarkUI.Forms;
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


        internal class AdbLine
        {
            #region Member Variables/Properties
            public string LineText { get; set; } = String.Empty;
            public string StackTraceText { get; set; } = String.Empty;
            public int LogType { get; set; } = 0;
            public bool IsCrLine { get; set; } = false;
            public bool IsTerms { get; set; } = true;
            public bool IsCurSearch { get; set; }
            #endregion
        }
        internal List<AdbLine> Lines { get; private set; }

        private System.Timers.Timer timer;

        private const string BoxCaption = "Adb 提示";

        public AdbClient(DocLogFile page)
        {
            pageForm = page;
            DevicesIdList = new List<string>();
            DevicesNameList = new List<string>();
            Lines = new List<AdbLine>();
            timer = new System.Timers.Timer(300);
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
        }

        private string GetPath()
        {
            return System.IO.Path.Combine(Misc.GetApplicationDirectory(), "adb.exe");
        }

        public void GetDevices()
        {
            GetDevicesInter();
        }

        public void ChooseDevice(int index)
        {
            ChooseDeviceInter(DevicesIdList[index]);
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
                    DarkMessageBox.ShowError(e.Message, BoxCaption);
                }

                IsBusying = false;
                pageForm.BeginInvoke(new Action(() =>
                {
                    pageForm.RefreshAdbDevicesList();
                }));
            });
        }

        private void ChooseDeviceInter(string deviceId)
        {
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

            adbProcess.OutputDataReceived += (sender, e) =>
            {
                var line = e.Data;
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }
                Console.WriteLine(line);
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
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    DarkMessageBox.ShowError(e.Message, BoxCaption);
                }
            });
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
            lock (Lines)
            {
                if (Lines.Count > 0)
                {
                    // 如果最后一行还没有结束，先不处理，前提是显示unity日志
                    if (!Lines[Lines.Count - 1].IsCrLine)
                    {
                        return;
                    }

                    pageForm.Log.WriteAdbLines(Lines);
                    Lines.Clear();
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
                lock (Lines)
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
                var newLine = new AdbLine { LineText = line, LogType = logType };
                Lines.Add(newLine);
            }
            else if (Lines.Count > 0)
            {
                Lines[Lines.Count - 1].StackTraceText += line + "\r\n";
            }
        }
    }
}