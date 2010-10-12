using System;
using System.Runtime.InteropServices;
using ComType = System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace TaskManager.Controller
{
    class ProcessCPU
    {
        // gets a process list pointer
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateToolhelp32Snapshot(uint Flags, uint ProcessID);

        // gets the first process in the process list
        [DllImport("KERNEL32.DLL")]
        public static extern bool Process32First(IntPtr Handle, ref ProcessEntry32 ProcessInfo);

        // gets the next process in the process list
        [DllImport("KERNEL32.DLL")]
        public static extern bool Process32Next(IntPtr Handle, ref ProcessEntry32 ProcessInfo);

        // closes handles
        [DllImport("KERNEL32.DLL")]
        public static extern bool CloseHandle(IntPtr Handle);

        // gets the process handle
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(
            uint DesiredAccess, 
            bool InheritHandle,
            uint ProcessId);

        // gets the process creation, exit, kernel and user time 
        [DllImport("kernel32.dll")]
        public static extern bool GetProcessTimes(
            IntPtr ProcessHandle,
            out ComType.FILETIME CreationTime,
            out ComType.FILETIME ExitTime,
            out ComType.FILETIME KernelTime,
            out ComType.FILETIME UserTime);

        // some consts will need later
        public const int PROCESS_ENTRY_32_SIZE = 296;
        public const uint TH32CS_SNAPPROCESS = 0x00000002;
        public const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        public static readonly IntPtr PROCESS_LIST_ERROR = new IntPtr(-1);
        public static readonly IntPtr PROCESS_HANDLE_ERROR = new IntPtr(-1);
    }

    // holds the process data
    public class ProcessData
    {
        public uint ID;
        public string Name;
        long OldUserTime;
        long OldKernelTime;
        DateTime OldUpdate;
        public string CpuUsage;
        public int Index;
        
      //  public ListViewItem ProcessItem;
        
        public ProcessData()
        {
        }

        public ProcessData(uint ID,string Name, long OldUserTime, long OldKernelTime)
        {
            this.ID = ID;
            this.Name = Name;
            this.OldUserTime = OldUserTime;
            this.OldKernelTime = OldKernelTime;
            OldUpdate = DateTime.Now;
        }

        public string UpdateCpuUsage(long NewUserTime, long NewKernelTime)
        {
            // updates the cpu usage (cpu usgae = UserTime + KernelTime)
            long UpdateDelay;
            long UserTime = NewUserTime - OldUserTime;
            long KernelTime = NewKernelTime - OldKernelTime;
            int RawUsage;

            // eliminates "divided by zero"
            if (DateTime.Now.Ticks == OldUpdate.Ticks) Thread.Sleep(100);

            UpdateDelay = DateTime.Now.Ticks - OldUpdate.Ticks;

            RawUsage = (int) (((UserTime + KernelTime) * 100) / UpdateDelay);
            //CpuUsage = ((UserTime + KernelTime) * 100) / UpdateDelay + "%";
            CpuUsage = RawUsage + "%";

            OldUserTime = NewUserTime;
            OldKernelTime = NewKernelTime;
            OldUpdate = DateTime.Now;

            //if (ProcessItem.SubItems[2].Text != CpuUsage)
            //    ProcessItem.SubItems[2].Text = CpuUsage;

            return CpuUsage;
        }
    
    }
}
