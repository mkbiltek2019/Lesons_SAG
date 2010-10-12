using System;
using System.Diagnostics;
using System.Net;
using System.Collections;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Management;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;

namespace ProcessInfo
{

    public static class Utils
    {
        public const int NO_ERROR = 0;
        public const int MIB_TCP_STATE_CLOSED = 1;
        public const int MIB_TCP_STATE_LISTEN = 2;
        public const int MIB_TCP_STATE_SYN_SENT = 3;
        public const int MIB_TCP_STATE_SYN_RCVD = 4;
        public const int MIB_TCP_STATE_ESTAB = 5;
        public const int MIB_TCP_STATE_FIN_WAIT1 = 6;
        public const int MIB_TCP_STATE_FIN_WAIT2 = 7;
        public const int MIB_TCP_STATE_CLOSE_WAIT = 8;
        public const int MIB_TCP_STATE_CLOSING = 9;
        public const int MIB_TCP_STATE_LAST_ACK = 10;
        public const int MIB_TCP_STATE_TIME_WAIT = 11;
        public const int MIB_TCP_STATE_DELETE_TCB = 12;

        #region helper function

        const int MAXSIZE = 16384; // size _does_ matter

        public static string GetProcessInfoByPID(int PID, out string User, out string Domain, out string OwnerSID)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ProcessID");
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Description");
            //dt.Columns.Add("User");
            //dt.Columns.Add("Domain");
            //dt.Columns.Add("OwnerSID");
            User = String.Empty;
            Domain = String.Empty;
            OwnerSID = String.Empty;
            string processname = String.Empty;
            try
            {

                ObjectQuery sq = new ObjectQuery("Select * from Win32_Process Where ProcessID = '" + PID + "'");
                //ObjectQuery sq = new ObjectQuery(Query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(sq);
                if (searcher.Get().Count == 0)
                    return "Unknown";
                foreach (ManagementObject oReturn in searcher.Get())
                {
                    //Name of process
                    //arg to send with method invoke to return user and domain - below is link to SDK doc on it

                    string[] o = new String[2];
                    //Invoke the method and populate the o var with the user name and domain
                    oReturn.InvokeMethod("GetOwner", (object[])o);

                    //int pid = (int)oReturn["ProcessID"];
                    processname = (string)oReturn["Name"];
                    //dr[2] = oReturn["Description"];
                    User = o[0];
                    if (User == null)
                        User = String.Empty;
                    Domain = o[1];
                    if (Domain == null)
                        Domain = String.Empty;
                    string[] sid = new String[1];
                    oReturn.InvokeMethod("GetOwnerSid", (object[])sid);
                    OwnerSID = sid[0];
		    return OwnerSID;
                }
            }
            catch 
            {
                return OwnerSID;
            }
            return OwnerSID;
        }
        
        public const int TOKEN_QUERY = 0X00000008;
        public static int PROCESS_TERMINATE = 0x0001;

        const int ERROR_NO_MORE_ITEMS = 259;

        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId
        }

        [StructLayout(LayoutKind.Sequential)]
        struct TOKEN_USER
        {
            public _SID_AND_ATTRIBUTES User;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct _SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public int Attributes;
        }

        [DllImport("advapi32")]
        public static extern bool OpenProcessToken(
            IntPtr ProcessIntPtr, // IntPtr to process
            int DesiredAccess, // desired access to process
            ref IntPtr TokenIntPtr // IntPtr to open access token
        );

        [DllImport("advapi32")]
        public static extern IntPtr OpenProcess(
            IntPtr ProcessIntPtr, // IntPtr to process
            int DesiredAccess, // desired access to process
            ref IntPtr TokenIntPtr // IntPtr to open access token
        );

        [DllImport("kernel32")]
         public static extern IntPtr OpenProcess(
                  int dwDesiredAccess,
                  bool bInheritHandle,
                  int dwProcessId
        );

        [DllImport("kernel32")]
        public static extern
           bool  TerminateProcess(
            IntPtr hProcess,
            int uExitCode
            );

      [DllImport("advapi32", CharSet = CharSet.Auto)]
        static extern bool GetTokenInformation(
            IntPtr hToken,
            TOKEN_INFORMATION_CLASS tokenInfoClass,
            IntPtr TokenInformation,
            int tokeInfoLength,
            ref int reqLength
        );


      [DllImport("kernel32", SetLastError = true),
      SuppressUnmanagedCodeSecurity]
     public static extern bool CloseHandle(IntPtr handle);

        [DllImport("advapi32", CharSet = CharSet.Auto)]
        static extern bool LookupAccountSid
        (
            [In, MarshalAs(UnmanagedType.LPTStr)] string lpSystemName, // name of local or remote computer
            IntPtr pSid, // security identifier
            StringBuilder Account, // account name buffer
            ref int cbName, // size of account name buffer
            StringBuilder DomainName, // domain name
            ref int cbDomainName, // size of domain name buffer
            ref int peUse // SID type
            // ref _SID_NAME_USE peUse // SID type
        );

        [DllImport("advapi32", CharSet = CharSet.Auto)]
        static extern bool ConvertSidToStringSid(
            IntPtr pSID,
            [In, Out, MarshalAs(UnmanagedType.LPTStr)] ref string pStringSid
        );

        [DllImport("advapi32", CharSet = CharSet.Auto)]
        static extern bool ConvertStringSidToSid(
            [In, MarshalAs(UnmanagedType.LPTStr)] string pStringSid,
            ref IntPtr pSID
        );

        /// <summary>
        /// Collect User Info
        /// </summary>
        /// <param name="pToken">Process IntPtr</param>
        public static bool DumpUserInfo(IntPtr pToken,  out IntPtr SID)
        {
            int Access = TOKEN_QUERY;
            IntPtr procToken = IntPtr.Zero;
            bool ret = false;
            SID = IntPtr.Zero;
            try
            {
                if (OpenProcessToken(pToken, Access, ref procToken))
                {
                    ret = ProcessTokenToSid(procToken, out SID);
                    CloseHandle(procToken);
                }
                return ret;
            }
            catch (Exception err)
            {
               //log.Error("Method [" + new StackFrame(0).GetMethod().Name + "]. Error " + err.Message);
                return false;
            }
        }

        private static bool ProcessTokenToSid(IntPtr token, out IntPtr SID)
        {
            TOKEN_USER tokUser;
            const int bufLength = 256;
            IntPtr tu = Marshal.AllocHGlobal(bufLength);
            bool ret = false;
            SID = IntPtr.Zero;
            try
            {
                int cb = bufLength;
                ret = GetTokenInformation(token, TOKEN_INFORMATION_CLASS.TokenUser, tu, cb, ref cb);
                if (ret)
                {
                    tokUser = (TOKEN_USER)Marshal.PtrToStructure(tu, typeof(TOKEN_USER));
                    SID = tokUser.User.Sid;
                }
                return ret;
            }
            catch (Exception err)
            {
                //log.Error("Method [" + new StackFrame(0).GetMethod().Name + "]. Error " + err.Message);
                return false;
            }
            finally
            {
                Marshal.FreeHGlobal(tu);
            }
        }

        public static string ExGetProcessInfoByPID(int PID, out string SID)//, out string OwnerSID)
        {
            IntPtr _SID = IntPtr.Zero;
            SID = String.Empty;
            try
            {
                Process process = Process.GetProcessById(PID);
                if (DumpUserInfo(process.Handle, out _SID))
                {
                    ConvertSidToStringSid(_SID, ref SID); 
                }
                return process.ProcessName;
            }
            catch
            {
                return "Unknown";
            }
        }

        #endregion
    }
}
