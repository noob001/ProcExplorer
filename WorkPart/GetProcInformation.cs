using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Management;


namespace WorkPart
{
    public partial class GetProcInformation
    {
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

        #region constr
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
                return Marshal.SizeOf(ProcList[ProcNumber].SafeHandle.DangerousGetHandle()).ToString();
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

        public string GetProcOwner()
        {
            var query = string.Format("SELECT ProcessId FROM Win32_Process WHERE ParentProcessId = {0}", GetProcID());
            var search = new ManagementObjectSearcher("root\\CIMV2", query);
            foreach (var ParentResult in search.Get())
            {
                try
                {
                    var ParentId = (uint)ParentResult["ProcessID"];
                    Process Parent = Process.GetProcessById((int)ParentId);
                    return Parent.ProcessName;
                }
                catch(ManagementException)
                {
                    return "NoOwner";
                }
            }


            return "getprocowner";
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

       /* public ProcInf GetInfForRow()
        {
            return new ProcInf(GetProcName(), GetProcID()," GetProcFullName()"," ", GetProcType());
        }
        */
        #endregion

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
