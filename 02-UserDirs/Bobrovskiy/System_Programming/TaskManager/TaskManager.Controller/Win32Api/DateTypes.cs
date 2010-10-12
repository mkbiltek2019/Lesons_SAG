using System;
using System.Runtime.InteropServices;
using ComType = System.Runtime.InteropServices.ComTypes;

namespace TaskManager.Controller
{
    //holds the time data
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        [MarshalAs(UnmanagedType.U2)]
        public short Year;
        [MarshalAs(UnmanagedType.U2)]
        public short Month;
        [MarshalAs(UnmanagedType.U2)]
        public short DayOfWeek;
        [MarshalAs(UnmanagedType.U2)]
        public short Day;
        [MarshalAs(UnmanagedType.U2)]
        public short Hour;
        [MarshalAs(UnmanagedType.U2)]
        public short Minute;
        [MarshalAs(UnmanagedType.U2)]
        public short Second;
        [MarshalAs(UnmanagedType.U2)]
        public short Milliseconds;
    }

    // holds the process info.
    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessEntry32
    {
        public uint Size;
        public uint Usage;
        public uint ID;
        public IntPtr DefaultHeapID;
        public uint ModuleID;
        public uint Threads;
        public uint ParentProcessID;
        public int PriorityClassBase;
        public uint Flags;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string ExeFilename;
    };

    // holds the process time data.
    public struct ProcessTimes
    {
        public DateTime CreationTime, ExitTime, KernelTime, UserTime;
        public ComType.FILETIME RawCreationTime;
        public ComType.FILETIME RawExitTime;
        public ComType.FILETIME RawKernelTime;
        public ComType.FILETIME RawUserTime;
     
        public void ConvertTime()
        {
            CreationTime = FiletimeToDateTime(RawCreationTime);
            ExitTime = FiletimeToDateTime(RawExitTime);
            KernelTime = FiletimeToDateTime(RawKernelTime);
            UserTime = FiletimeToDateTime(RawUserTime);
        }

        private DateTime FiletimeToDateTime(ComType.FILETIME FileTime)
        {
            try
            {
                if (FileTime.dwLowDateTime < 0) FileTime.dwLowDateTime = 0;
                if (FileTime.dwHighDateTime < 0) FileTime.dwHighDateTime = 0;

                long RawFileTime = (((long)FileTime.dwHighDateTime) << 32) + FileTime.dwLowDateTime;
                return DateTime.FromFileTimeUtc(RawFileTime);
            }
            catch { return new DateTime(); }
        }
    };
}
