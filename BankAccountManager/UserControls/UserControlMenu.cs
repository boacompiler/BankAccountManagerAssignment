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

        //We capture the enter key, allowing the user to press enter to search
        //We cannot use the MainForm accept button because that is a wider scope than needed to be captured
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                buttonSearch.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void FillView()
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
                        result = (string.Format("{0:C}", account.AccountBalance).Replace(",", "").ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 3:
                        if (account.customerAddress != null) result = (account.customerAddress.GetFullAddress().ToLower().Contains(textBoxSearch.Text.ToLower()));
                        break;
                    case 4:
                        if (account.customerPhone != null) result = (account.customerPhone.Number.ToLower().Contains(textBoxSearch.Text.ToLower().Replace(" ", "")));
                        break;
                    case 5:
                        if(account.CompanyName != null) result = (account.CompanyName.ToLower().Contains(textBoxSearch.Text.ToLower()));
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
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string accNo = listView1.SelectedItems[0].SubItems[6].Text;
                listView1.SelectedItems.Clear();
                Account editAccount = MainForm.myList.Find(x => x.AcountNumber == Int32.Parse(accNo));
                MainForm.editControl = new UserControlEdit(); //This is just a precaution, we don't want to accidentally edit the wrong account, so we reinitialise the control 
                MainForm.editControl.setAccount(editAccount);
                MainForm.ucm.DisplayControl(MainForm.editControl);
            }
            catch (Exception)
            {

                MessageBox.Show("Select an account to edit","Error");
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MainForm.addControl = new UserControlAdd();//This is just a precaution, we don't want to accidentally addd an existing account
            MainForm.ucm.DisplayControl(MainForm.addControl);
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            try
            {
                string accNo = listView1.SelectedItems[0].SubItems[6].Text;
                listView1.SelectedItems.Clear();
                Account viewAccount = MainForm.myList.Find(x => x.AcountNumber == Int32.Parse(accNo));
                MainForm.viewControl.setAccount(viewAccount);
                MainForm.ucm.DisplayControl(MainForm.viewControl);
            }
            catch (Exception)
            {

                MessageBox.Show("Select an account to view", "Error");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();
            Account deleteAccount = new Account();

            try
            {
                string accNo = listView1.SelectedItems[0].SubItems[6].Text;
                listView1.SelectedItems.Clear();
                deleteAccount = MainForm.myList.Find(x => x.AcountNumber == Int32.Parse(accNo));

                result = MessageBox.Show("Do you want to permanently remove " + deleteAccount.CustomerName.GetFullName() + "'s account?",
                                                  "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {

                MessageBox.Show("Select an account to delete", "Error");
            }

            if (result == DialogResult.Yes)
            {
                try
                {
                    MainForm.myList.Remove(deleteAccount);
                    FillView();
                    MainForm.myXML.Serialise(MainForm.myList);
                    MainForm.menuControl.FillView();
                }
                catch (Exception)
                {

                    MessageBox.Show("Cannot delete account", "Error");
                }
            }
            
        }
    }
}
