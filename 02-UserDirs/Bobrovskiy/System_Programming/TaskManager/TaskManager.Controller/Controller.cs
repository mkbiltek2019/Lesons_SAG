using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TaskManager.Controller
{
    public class DataExtractor
    { 
        public int ProcessCount
        {
            get
            {
                return Process.GetProcesses().Count();
            }
        }

        private string ParsePriority(int basePriority)
        {
            const int Idle = 4;
            const int Normal = 8;
            const int High = 13;
            const int RealTime = 24;

            string priority = string.Empty;

            if (basePriority <= Idle)
            {
                priority = "Idle";
            }

            if ((Idle < basePriority) && (basePriority < Normal))
            {
                priority = "BelowNormal";
            }

            if (basePriority == Normal)
            {
                priority = "Normal";
            }

            if ((Normal < basePriority) && (basePriority < High))
            {
                priority = "AboveNormal";
            }

            if ((basePriority >= High) && (basePriority < RealTime))
            {
                priority = "High";
            }

            if (basePriority >= RealTime)
            {
                priority = "RealTime";
            }

            return priority;
        }

        public List<TaskManagerModel> ExtractData()
        {
            List<TaskManagerModel> dataList = new List<TaskManagerModel>();

            List<Process> processes = Process.GetProcesses().ToList();
            //ProcessTimes proc = new ProcessTimes();
            //ProcessData procData = new ProcessData();

            for (int i = 0; i < processes.Count(); i++)
            {
                string userName = string.Empty;
                string basePriority = string.Empty;
                string processModuleName = string.Empty;
                string processDestinationFolder = string.Empty;
                string cpuUsage = string.Empty;

                TaskManagerModel model = null;

                try
                {
                    basePriority = ParsePriority(processes[i].BasePriority);
                    processModuleName = processes[i].MainModule.ModuleName;
                    string s1, s2, s3;
                    ProcessInfo.Utils.GetProcessInfoByPID(processes[i].Id, out s1, out s2, out s3);
                    userName = s1;

                    processDestinationFolder = processes[i].MainModule.FileName;

                    // cpuUsage = processes[i].TotalProcessorTime.Milliseconds.ToString();
                }
                catch (Win32Exception e)
                {
                    processModuleName = string.Format("{0}.exe", processes[i].ProcessName);
                    userName = "System";
                }
                finally
                {
                    model = new TaskManagerModel()
                    {
                        ProcessName = Convert.ToString(processes[i].ProcessName),
                        ProcessPID = processes[i].Id,
                        ThreadCount = processes[i].Threads.Count,
                        UserName = userName,
                        BasePriority = basePriority,
                        ProcessModuleName = processModuleName,
                        ProcessDestinationFolder = processDestinationFolder,
                      
                    };

                    dataList.Add(model);
                }

            }

            return dataList; 
        }

        public void KillProcessById(int pid)
        {
            System.IntPtr handler =
            ProcessInfo.Utils.OpenProcess(1, false, pid);

            ProcessInfo.Utils.TerminateProcess(handler, 0);
            ProcessInfo.Utils.CloseHandle(handler);

            
        }
    }
}
