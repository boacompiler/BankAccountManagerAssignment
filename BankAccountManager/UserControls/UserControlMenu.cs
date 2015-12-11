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
            listView1.Items.Clear();
            foreach (Account account in MainForm.myList)
            {
                ListViewItem item = new ListViewItem(new string[] { account.customerName.GetFullName(), account.Type, string.Format("{0:C}",account.AccountBalance.ToString()), "And so on" });//TODO finish
                listView1.Items.Add(item);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FillView();
            MessageBox.Show(MainForm.myList[0].customerName.GetFullName());
        }
    }
}
