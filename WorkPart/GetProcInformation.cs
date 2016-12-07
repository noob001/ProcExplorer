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

        public static void InitializeProcInf ()
            {
            SetProcList();
            procInfList = new List<GetProcInformation>();
            foreach(Process t in ProcList)
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
                return is64==0 ? "64bit": "32bit" ;
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

       /* public string GetProcOwner()
        {
           string[] propertiesToSelect = new[] { "Handle", "ProcessId" };
            string queryPartStr = "Name = '" +ProcInfList[ProcNumber].GetProcName()+ ".exe'";
            SelectQuery processQuery = new SelectQuery("Win32_Process", queryPartStr, propertiesToSelect);
   
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(processQuery))
            using (ManagementObjectCollection processes = searcher.Get())
                foreach (ManagementObject process in processes)
                {
                    object[] outParameters = new object[2];
                    uint result = (uint)process.InvokeMethod("GetOwner", outParameters);

                    if (result == 0)
                    {
                        string user = (string)outParameters[0];
                        string domain = (string)outParameters[1];
                        uint processId = (uint)process["ProcessId"];
                        return user;
                        // Use process data...
                    }
                    else
                    {
                        return "NoOwnerInformation";
                    }
                }
            return "System";
        }*/

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
                name = "ProcessName";
                return "Process_End";                
            }

        }

        public List <string> GetModuleNames()
        {
            List <string> mList = new List<string>();
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
            
            ParentPID =  (int)parentInf.NextValue();
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

        public bool GetAslrPolicy (out string bottomUpRandomization, out string forceRelocateImages, out string highEntropy, out string disallowStrippedImages)
            { 

            }
        

       /* public ProcInf GetInfForRow()
        {
            return new ProcInf(GetProcName(), GetProcID()," GetProcFullName()"," ", GetProcType());
        
        */
        #endregion



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
        uint Flags;
        bool Permanent;

        bool Enable
        {
            get { return (Flags & 1) > 0; }
        }

        bool DisableAtlThunkEmulation
        {
            get { return (Flags & 2) > 0; }
        }
    }

    public enum Process_Mitigation_Policy
    {
        ProcessDEPPolicy = 0,
        ProcessASLRPolicy = 1
    }

    public struct ProcInf
    {
        public string PName { get; set; }
        public int PID { get; set; }
        public string PFullName { get; set; }
        public string POwner { get; set; }
        public string Type { get; set; }

        public ProcInf (string name, int id, string fullname, string owner, string type)
        {
            PName = name;
            PID = id;
            PFullName = fullname;
            POwner = owner;
            Type = type;
        }
    }


}
