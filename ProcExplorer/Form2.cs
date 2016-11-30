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
    public partial class Form2 : Form
    {
        public int Index { get; set; }
        public Form2(int index)
        {
            InitializeComponent();
            Index = index;
        }

        private void Modules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Modules.Items.Clear();
            foreach (string name in GetProcInformation.ProcInfList[Index].GetModuleNames())
            Modules.Items.Add(name);
        }
    }
}
