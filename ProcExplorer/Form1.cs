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
            RefreshTable();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void Modules_Click(object sender, EventArgs e)
        {
            ViewModules();
        }

        private void RefreshTable ()
        {
            ProcDataGrid.Rows.Clear();
            GetProcInformation.InitializeProcInf();
            foreach (GetProcInformation inf in GetProcInformation.ProcInfList)
            {
                ProcDataGrid.Rows.Add(inf.GetProcName(), inf.GetProcID(), inf.GetProcFullName(), inf.GetProcType());

            }

        }

        private void ViewModules()
        {
            Form2 form = new Form2(ProcDataGrid.CurrentRow.Index);
            form.ShowDialog();
        }

        private void ProcDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            //magicbutton!!!
            string name;
            int parPID;
            ParentName.Text = GetProcInformation.ProcInfList[ProcDataGrid.CurrentRow.Index].GetProcParentName(out parPID);
            ParentId.Text = parPID.ToString();
            SidInfo.Text = GetProcInformation.ProcInfList[ProcDataGrid.CurrentRow.Index].GetProcOwnerSidName(out name);
            OwnerName.Text = name;
        }

        private void OwnerName_Click(object sender, EventArgs e)
        {

        }
    }

}

