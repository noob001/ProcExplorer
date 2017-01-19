using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Management;
using zmland.Win32;
using System.Security.Principal;

namespace WorkPart
{
    public partial class GetProcInformation
    {
        #region Import
        // Для ASLR
        [DllImport("kernel32.dll")]
        static extern bool GetProcessMitigationPolicy(
            IntPtr hProcess,
            Process_Mitigation_Policy mitigationPolicy,
            ref ProcessDEP lpBuffer,
            int dwLength);

        // Для DEP
        [DllImport("kernel32.dll")]
        static extern bool GetProcessMitigationPolicy(
            IntPtr hProcess,
            Process_Mitigation_Policy mitigationPolicy,
            ref ProcessASLR lpBuffer,
            int dwLength);

        #endregion

        #region Static Props&Methods

        private static List<Process> ProcList { get; set; }

        private static List<GetProcInformation> procInfList;

        public static List<GetProcInformation> ProcInfList { get { return procInfList; } }

        private static void SetProcList()
        {
            ProcList = Process.GetProcesses().ToList();
        }

        public static void InitializeProcInf()
        {
            SetProcList();
            procInfList = new List<GetProcInformation>();
            foreach (Process t in ProcList)
            {
                procInfList.Add(new GetProcInformation(procInfList.Count));
            }
        }

        #endregion

        #region construct
        public GetProcInformation(int number)
        {
            ProcNumber = number;
        }
        #endregion

        public int ProcNumber { get; set; }

        #region GetInfo


        public string GetProcName()
        {
            return ProcList[ProcNumber].ProcessName;
        }

        public int GetProcID()
        {
            return ProcList[ProcNumber].Id;
        }

        public string GetProcFullName()
        {
            try
            {
                return ProcList[ProcNumber].MainModule.FileName;
            }
            catch (Win32Exception e)
            {
                return "Acess_denied";
            }
            catch (InvalidOperationException)
            {
                return "Process_End";
            }

        }

        public string GetProcType()
        {
            try
            {
                int is64 = 0;
                NativeMethods.IsWow64Process(ProcList[ProcNumber].Handle, out is64);
                return is64 == 0 ? "64bit" : "32bit";
            }
            catch (Win32Exception e)
            {
                return "Acess_denied";
            }
            catch (InvalidOperationException)
            {
                return "Process_End";
            }
        }

        public string GetProcOwnerSidName(out string name)
        {
            try
            {
                IntPtr procHandle = IntPtr.Zero;
                NativeMethods.OpenProcessToken(ProcList[ProcNumber].Handle, 8, out procHandle);
                WindowsIdentity user = new WindowsIdentity(procHandle);
                name = user.Name;
                return "{" + user.User.Value + "}";
            }
            catch (Win32Exception e)
            {
                name = "acess_denied";
                return "Acess_denied";
            }
            catch (InvalidOperationException)
            {
                name = "Process_end";
                return "Process_End";
            }

        }

        public List<string> GetModuleNames()
        {
            List<string> mList = new List<string>();
            try
            {
                foreach (ProcessModule pm in ProcList[ProcNumber].Modules)
                {
                    mList.Add(pm.ModuleName);
                }
                return mList;
            }

            catch (Win32Exception)
            {
                mList.Add("Acess_denied");
                return mList;
            }
        }

        public string GetProcParentName(out int ParentPID)
        {
            try
            {
                PerformanceCounter parentInf = new PerformanceCounter("Process", "Creating Process ID", ProcInfList[ProcNumber].GetProcName());

                ParentPID = (int)parentInf.NextValue();
                string procParentName = Process.GetProcessById(ParentPID).ProcessName;
                return procParentName;
            }
            catch (Win32Exception e)
            {
                ParentPID = 0;
                return "Acess_denied";
            }
            catch (Exception)
            {
                ParentPID = 0;
                return "Process_End";
            }

        }

        public bool GetAslrPolicy(out string bottomUpRandomization, out string forceRelocateImages, out string highEntropy, out string disallowStrippedImages)
        {
            ProcessASLR aslr = new ProcessASLR();
            bool done = false;
            try
            {
                done = GetProcessMitigationPolicy(ProcList[ProcNumber].Handle, Process_Mitigation_Policy.ProcessASLRPolicy, ref aslr, Marshal.SizeOf(aslr));
            }
            catch (Win32Exception e)
            {
                bottomUpRandomization = "AcessDenied";
                forceRelocateImages = highEntropy = disallowStrippedImages = bottomUpRandomization;
                return done;
            }
            catch (Exception)
            {
                bottomUpRandomization = "Process_end";
                forceRelocateImages = highEntropy = disallowStrippedImages = bottomUpRandomization;
                return done;
            }

            if (done)
            {
                bottomUpRandomization = aslr.EnableBottomUpRandomization ? "Enable" : "Disable";
                forceRelocateImages = aslr.EnableForceRelocateImages ? "Enable" : "Disable";
                highEntropy = aslr.EnableHighEntropy ? "Enable" : "Disable";
                disallowStrippedImages = aslr.DisallowStrippedImages ? "Enable" : "Disable";
                return done;
            }
            else
            {
                bottomUpRandomization = "NoASLRInfo";
                forceRelocateImages = highEntropy = disallowStrippedImages = bottomUpRandomization;
                return done;
            }
        }

        public string GetDepPolicy()
        {
            if (GetProcType() == "64bit")
                return "Enable (Permanent)";

            string status;
            bool success = false;
            ProcessDEP depPolicy = new ProcessDEP();
            try
            {
                success = GetProcessMitigationPolicy(ProcList[ProcNumber].Handle, Process_Mitigation_Policy.ProcessDEPPolicy, ref depPolicy, Marshal.SizeOf(depPolicy));
            }
            catch { return "Acess_Denied"; }

            if (depPolicy.Enable)
            {
                status = "Enable";
                return status;
            }
            if (depPolicy.Permanent)
            {
                status = "Enable";
                return status;
            }
            status = "Disable";
            return status;
        }


        #endregion

        const uint ERROR_INSUFFICIENT_BUFFER = 122;
        const long SECURITY_MANDATORY_UNTRUSTED_RID = 0x00000000L;
        const long SECURITY_MANDATORY_LOW_RID = 0x00001000L;
        const long SECURITY_MANDATORY_MEDIUM_RID = 0x00002000L;
        const long SECURITY_MANDATORY_HIGH_RID = 0x00003000L;
        const long SECURITY_MANDATORY_SYSTEM_RID = 0x00004000L;

        [StructLayout(LayoutKind.Sequential)]
        struct TOKEN_MANDATORY_LABEL
        {
            public SID_AND_ATTRIBUTES Label;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public int Attributes;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle,
            TokenAccessLevels DesiredAccess,
            out IntPtr TokenHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetTokenInformation(IntPtr TokenHandle,
            TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation,
            uint TokenInformationLength,
            out uint ReturnLength);

        [DllImport("kernel32.dll")]
        static extern IntPtr LocalAlloc(uint uFlags, UIntPtr uBytes);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthority(IntPtr pSid, int nSubAuthority);

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern IntPtr GetSidSubAuthorityCount(IntPtr pSid);

        public string GetProcIntgLvl( )
        {
            IntPtr hProcess = ProcList[ProcNumber].Handle;
            IntPtr hToken;
            uint dwError=0;
            IntPtr pTIL;
            TOKEN_MANDATORY_LABEL TIL;
            string d = "no inf";

            if (!OpenProcessToken(hProcess, TokenAccessLevels.MaximumAllowed, out hToken))
            {
                return d;
            }
                uint dwLengthNeeded;
                if (GetTokenInformation(hToken,TOKEN_INFORMATION_CLASS.TokenIntegrityLevel,IntPtr.Zero, 0, out dwLengthNeeded))
                    dwError = (uint)Marshal.GetLastWin32Error();

                if (dwError == ERROR_INSUFFICIENT_BUFFER)
                {
                    pTIL = Marshal.AllocHGlobal((int)dwLengthNeeded);

                        if (!GetTokenInformation(hToken,TOKEN_INFORMATION_CLASS.TokenIntegrityLevel,pTIL,dwLengthNeeded,out dwLengthNeeded))
                        {
                            d="no info5";
                        }

                        TIL =(TOKEN_MANDATORY_LABEL)Marshal.PtrToStructure(pTIL,typeof(TOKEN_MANDATORY_LABEL));

                        IntPtr SubAuthorityCount = GetSidSubAuthorityCount(TIL.Label.Sid);

                        IntPtr IntegrityLevelPtr = GetSidSubAuthority(TIL.Label.Sid,
                            Marshal.ReadByte(SubAuthorityCount) - 1);

                        int dwIntegrityLevel = Marshal.ReadInt32(IntegrityLevelPtr);

                        if (dwIntegrityLevel == SECURITY_MANDATORY_LOW_RID)
                        {
                            // Untrusted Integrity
                            d = "Untrusted Process";
                        }
                         else if(dwIntegrityLevel == SECURITY_MANDATORY_LOW_RID)
                        {
                            // Low Integrity
                            d= "Low Process";
                        }
                        else if (dwIntegrityLevel >= SECURITY_MANDATORY_MEDIUM_RID)
                        {
                            // Medium Integrity
                            d= "Medium Process";
                        }
                        else if (dwIntegrityLevel >= SECURITY_MANDATORY_HIGH_RID )
                        {
                            // High Integrity
                            d= "High Integrity Process";
                        }
                        else if (dwIntegrityLevel >= SECURITY_MANDATORY_SYSTEM_RID)
                        {
                            // System Integrity
                            d = "System Integrity Process";
                        }

                }
                CloseHandle(hToken);
            return d;
        }


        public string GetProcessIntegrityLevel()
        {
            int IL = -1;
            IntPtr hToken= IntPtr.Zero;
            uint cbTokenIL = 0;
            IntPtr pTokenIL = IntPtr.Zero;
            string d = "";

            try
            {
                if (!OpenProcessToken(ProcList[ProcNumber].Handle, TokenAccessLevels.Query, out hToken))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }


                if (!GetTokenInformation(hToken, TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, IntPtr.Zero, 0,out cbTokenIL))
                {
                    int error = Marshal.GetLastWin32Error();
                    if (error != ERROR_INSUFFICIENT_BUFFER)
                    {

                        throw new Win32Exception(error);
                    }
                }

                pTokenIL = Marshal.AllocHGlobal((int)cbTokenIL) ;
                if (pTokenIL == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                if (!GetTokenInformation(hToken,
                    TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenIL, cbTokenIL,
                    out cbTokenIL))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                TOKEN_MANDATORY_LABEL tokenIL = (TOKEN_MANDATORY_LABEL)
                Marshal.PtrToStructure(pTokenIL, typeof(TOKEN_MANDATORY_LABEL));

                IntPtr pIL =GetSidSubAuthority(tokenIL.Label.Sid, 0);
                IL = Marshal.ReadInt32(pIL);


                
                if (IL == SECURITY_MANDATORY_UNTRUSTED_RID)
                {
                    // Untrusted Integrity
                    d = "Untrusted Process";
                }
                else if (IL == SECURITY_MANDATORY_LOW_RID)
                {
                    // Low Integrity
                    d = "Low Process";
                }
                else if (IL == SECURITY_MANDATORY_MEDIUM_RID)
                {
                    // Medium Integrity
                    d = "Medium Process";
                }
                else if (IL == SECURITY_MANDATORY_HIGH_RID)
                {
                    // High Integrity
                    d = "High Integrity Process";
                }
                else if (IL == SECURITY_MANDATORY_SYSTEM_RID)
                {
                    // System Integrity
                    d = "System Integrity Process";
                }


            }
            finally
            {

                if (hToken != null)
                {
                    CloseHandle(hToken);
                    hToken = IntPtr.Zero;
                }
                if (pTokenIL != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pTokenIL);
                    pTokenIL = IntPtr.Zero;
                    cbTokenIL = 0;
                }
            }

            return d;
        }
    }


    struct ProcessASLR
    {
        public uint Flags;
        public bool EnableBottomUpRandomization { get { return (Flags & 1) > 0; } }
        public bool EnableForceRelocateImages { get { return (Flags & 2) > 0; } }
        public bool EnableHighEntropy { get { return (Flags & 4) > 0; } }
        public bool DisallowStrippedImages { get { return (Flags & 8) > 0; } }
    }

    struct ProcessDEP
    {
        public uint Flags;
        public bool Permanent;
        public bool Enable
        {
            get { return (Flags & 1) > 0; }
        }
        public bool DisableAtlThunkEmulation
        {
            get { return (Flags & 2) > 0; }
        }
    }

    public enum Process_Mitigation_Policy
    {
        ProcessDEPPolicy = 0,
        ProcessASLRPolicy = 1
    }

}

    enum TOKEN_INFORMATION_CLASS
{
    TokenUser = 1,
    TokenGroups = 2,
    TokenPrivileges = 3,
    TokenOwner = 4,
    TokenPrimaryGroup = 5,
    TokenDefaultDacl = 6,
    TokenSource = 7,
    TokenType = 8,
    TokenImpersonationLevel = 9,
    TokenStatistics = 10,
    TokenRestrictedSids = 11,
    TokenSessionId = 12,
    TokenGroupsAndPrivileges = 13,
    TokenSessionReference = 14,
    TokenSandBoxInert = 15,
    TokenAuditPolicy = 16,
    TokenOrigin = 17,
    TokenElevationType = 18,
    TokenLinkedToken = 19,
    TokenElevation = 20,
    TokenHasRestrictions = 21,
    TokenAccessInformation = 22,
    TokenVirtualizationAllowed = 23,
    TokenVirtualizationEnabled = 24,
    TokenIntegrityLevel = 25,
    TokenUIAccess = 26,
    TokenMandatoryPolicy = 27,
    TokenLogonSid = 28,
    MaxTokenInfoClass = 29
}
