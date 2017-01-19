using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkPart;

namespace ProcExplorer
{
    public partial class Form3 : Form
    {
        string name;
        public Form3()
        {
            InitializeComponent();
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string name in GetUserInfo.Getgroups(out name) )
                listBox1.Items.Add(name);
        }
    }
}
