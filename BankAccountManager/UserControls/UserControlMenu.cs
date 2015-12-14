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
                        if (account.customerName != null) result = (account.CustomerName.GetFullName().ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 1:
                        if (account.Type != null) result = (account.Type.ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 2:
                        result = (string.Format("{0:C}", account.AccountBalance).Replace(",", "").ToLower().Contains(textBoxSearch.Text.ToLower()));//No check for null because decimal is not nullable
                        break;
                    case 3:
                        if (account.customerAddress != null) result = (account.customerAddress.GetFullAddress().ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 4:
                        if (account.customerPhone != null) result = (account.customerPhone.Number.ToLower().Contains(textBoxSearch.Text.ToLower().Replace(" ", "")));
                        break;
                    case 5:
                        if(account.CompanyName != null) result = (account.CompanyName.ToLower().Contains(textBoxSearch.Text.ToLower()));//TODO handle for null
                        break;
                }

                if (result || textBoxSearch.Text == "")
                {
                    ListViewItem item = new ListViewItem(new string[] 
                    { 
                        (account.customerName != null)? account.customerName.GetFullName() : null, 
                        (account.Type != null)? account.Type : null, 
                        string.Format("{0:C}", account.AccountBalance), 
                        (account.customerAddress != null)? account.customerAddress.GetFullAddress() : null, 
                        (account.customerPhone != null)? account.customerPhone.Number : null, 
                        (account.CompanyName != null)? account.CompanyName : null,
                        account.AcountNumber.ToString()
                    });//TODO finish

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
            //MessageBox.Show(""+listView1.SelectedItems[0].SubItems[1].Text);
            MainForm.editControl.setAccount(0);//TODO testing
            MainForm.editControl.refresh();
            
            MainForm.ucm.DisplayControl(MainForm.editControl);
        }
    }
}
