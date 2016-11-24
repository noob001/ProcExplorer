using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WorkPart
{
    public partial class GetProcInformation
    {
        #region Static Props&Methods

        private static IEnumerable<Process> ProcList { get; set; }

        public static void SetProcList()
        {
            ProcList = Process.GetProcesses();
        }

        public static List<GetProcInformation> InitializeProcInf ()
            {
            List < GetProcInformation > Processes = new List<GetProcInformation>();

            foreach(Process t in ProcList)
                {
                    Processes.Add(new GetProcInformation(Processes.Count));
                }
            return Processes;

            }


        #endregion

        private int ProcNumber { get; set; }

        public GetProcInformation(int number)
        {
            ProcNumber = number;
        }

        public string GetProcName()
        {
            return "";
        }

    }
}
