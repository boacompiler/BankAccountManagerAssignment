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
            comboBoxAccountCriteria.DataSource = new string[] {"Customer Name", "Account Type", "Account Balance", "Address", "Phone Number", "Company Name"};

            FillView();
        }

        void FillView()
        {
            listView1.Items.Clear();

            

            foreach (Account account in MainForm.myList)
            {
                bool result = false;
                switch (comboBoxAccountCriteria.SelectedIndex)
                {
                    default:
                    case 0:
                        result = (account.CustomerName.GetFullName().ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 1:
                        result = (account.Type.ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 2:
                        result = (account.AccountBalance.ToString().ToLower().Contains(textBoxSearch.Text.ToLower()));//TODO convert to currency is probably required
                        break;
                    case 3:
                        result = (account.customerAddress.GetFullAddress().ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 4:
                        result = (account.customerPhone.Number.ToLower().Contains(textBoxSearch.Text.ToLower()));//TODO strip spaces
                        break;
                    case 5:
                        result = (account.CompanyName.ToLower().Contains(textBoxSearch.Text.ToLower()));//TODO handle for null
                        break;
                }

                if (result || textBoxSearch.Text == "")
                {
                    ListViewItem item = new ListViewItem(new string[] { account.customerName.GetFullName(), account.Type, string.Format("{0:C}", account.AccountBalance), account.customerAddress.GetFullAddress(), account.customerPhone.Number, account.CompanyName });//TODO finish
                    listView1.Items.Add(item);
                }
                
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FillView();
            //MessageBox.Show(MainForm.myList[0].customerName.GetFullName());
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            MainForm.ucm.DisplayControl(MainForm.editControl);
        }
    }
}
