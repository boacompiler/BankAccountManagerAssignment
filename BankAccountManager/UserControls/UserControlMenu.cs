using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BankAccountManager.Classes;

namespace BankAccountManager.UserControls
{
    public partial class UserControlMenu : UserControl
    {
        public UserControlMenu()
        {
            InitializeComponent();
            
        }

        void FillView()
        {
            foreach (Account account in MainForm.myList)
            {
                ListViewItem item = new ListViewItem(new string[] { account.customerName.GetFullName(), account.Type, "SubItem3", "And so on" });
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillView();
        }
    }
}
