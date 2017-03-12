using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WorkPart;
using System.Security.Principal;

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

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            GetUserInfo.AddUserToLocalGroup(currentUser.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
          //  GetUserInfo.AddUserToLocalGroup(currentUser.Name, listBox1.SelectedIndex);
        }
    }
}
