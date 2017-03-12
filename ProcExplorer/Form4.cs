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
    public partial class Form4 : Form
    {
        int Index;
        public Form4(int index)
        {
            InitializeComponent();
            Index= index;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetProcInformation.ProcInfList[Index].SetProcessIntegrityLevel(0x00000000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetProcInformation.ProcInfList[Index].SetProcessIntegrityLevel(0x00001000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetProcInformation.ProcInfList[Index].SetProcessIntegrityLevel(0x00002000);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetProcInformation.ProcInfList[Index].SetProcessIntegrityLevel(0x00003000);
        }
    }
}
