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
                string t = "";
                try
                {
                    t = inf.GetProcessIntegrityLevel().ToString();
                }
                catch (Exception tre)
                {
                    t = tre.Message;
                }
                ProcDataGrid.Rows.Add(inf.GetProcName(), inf.GetProcID(), inf.GetProcFullName(), inf.GetProcType(), t);
                

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
            string bottomUpRandomization;
            string forceRelocateImages;
            string highEntropy;
            string disallowStrippedImages;

            ParentName.Text = GetProcInformation.ProcInfList[ProcDataGrid.CurrentRow.Index].GetProcParentName(out parPID);
            ParentId.Text = parPID.ToString();
            SidInfo.Text = GetProcInformation.ProcInfList[ProcDataGrid.CurrentRow.Index].GetProcOwnerSidName(out name);
            OwnerName.Text = name;
            DEP.Text = GetProcInformation.ProcInfList[ProcDataGrid.CurrentRow.Index].GetDepPolicy();
            GetProcInformation.ProcInfList[ProcDataGrid.CurrentRow.Index].GetAslrPolicy(out bottomUpRandomization, out forceRelocateImages, out highEntropy, out disallowStrippedImages);
            BottomUpRandomization.Text= bottomUpRandomization;
            ForceRelocateImages.Text= forceRelocateImages;
            HighEntropy.Text = highEntropy;
            DisallowStrippedImages.Text = disallowStrippedImages;
            try
            {
                IntegrityLvl.Text = GetProcInformation.ProcInfList[ProcDataGrid.CurrentRow.Index].GetProcessIntegrityLevel().ToString();
            }

            catch(Exception tre)
            {
                IntegrityLvl.Text = tre.Message;
            }

        }

        private void forceRelocateImagesLbl_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupsButton_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProcDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChangeIntegrity_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(ProcDataGrid.CurrentRow.Index);
            form.ShowDialog();
        }
    }

}

