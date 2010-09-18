using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProcessDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            foreach (var proc in processes)
            {
                Console.WriteLine(proc.ProcessName);
            }
            Console.ReadLine();

            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo("conf.exe");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            processStartInfo.WorkingDirectory = "C:\\";

            process.StartInfo = processStartInfo;
            process.Start();

            Console.WriteLine("process.StartTime is {0}", process.StartTime.ToLongTimeString());

            ProcessModule processModule = process.MainModule;

            while (!process.HasExited)
            {
                Console.ReadLine();    
            }

            Console.WriteLine("process.ExitTime is {0}", process.ExitTime.ToLongTimeString());
            Console.WriteLine("process.ExitCode is {0}", process.ExitCode);

            Console.ReadLine();

            Process calcProcess = Process.Start("calc.exe");
            if (calcProcess != null) calcProcess.Close();

            Process.EnterDebugMode();
            Process.LeaveDebugMode();
        }
    }
}
