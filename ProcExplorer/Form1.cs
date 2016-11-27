using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkPart;

namespace ProcExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            GetProcInformation.InitializeProcInf();
            foreach (GetProcInformation inf in GetProcInformation.ProcInfList)
            {
                ProcDataGrid.Rows.Add(inf.GetProcName(), inf.GetProcID(), inf.GetProcFullName(), inf.GetProcOwner(), inf.GetProcType());

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
