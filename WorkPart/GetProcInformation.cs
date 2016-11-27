using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;

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

        private int ProcNumber { get; set; }

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
        }

        public string GetProcOwner()
        {
            return "getprocowner";
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
