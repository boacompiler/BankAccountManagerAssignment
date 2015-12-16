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
    public partial class UserControlEdit : UserControl
    {
        private int AccountNumber;
        private Account account;

        public UserControlEdit()
        {
            InitializeComponent();
            comboBoxHonorific.DataSource = Enum.GetNames(typeof(Honorific));
            comboBoxType.DataSource = new string[] {"Current Account","Savings Account","Fixed Term Account"};

            
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {      
            switch (comboBoxType.SelectedIndex)
            {
                default:
                case 0:
                    panelSavingsAccount.Hide();
                    panelFixedTermAccount.Hide();
                    panelCurrentAccount.Show();
                    panelCurrentAccount.Dock = DockStyle.Fill;
                    break;
                case 1:
                    panelCurrentAccount.Hide();
                    panelFixedTermAccount.Hide();
                    panelSavingsAccount.Show();
                    panelSavingsAccount.Dock = DockStyle.Fill;
                    break;
                case 2:
                    panelCurrentAccount.Hide();
                    panelSavingsAccount.Hide();
                    panelFixedTermAccount.Show();
                    panelFixedTermAccount.Dock = DockStyle.Fill;
                    break;
            }
        }

        public void setAccount(int AccountNumber)
        {
            this.AccountNumber = AccountNumber;
            account = MainForm.myList[0]; //TODO testing
        }

        public void refresh()
        {
            comboBoxHonorific.SelectedItem = account.customerName.honorific.ToString();
            textBoxFirstName.Text = account.customerName.FirstName;
            textBoxSecondName.Text = account.customerName.SecondName;
            textBoxPhone.Text = account.customerPhone.Number;
            textBoxCompanyName.Text = (account.CompanyName != null)? account.CompanyName : null;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            account.CompanyName = textBoxCompanyName.Text;
            MainForm.myXML.Serialise(MainForm.myList);
            MainForm.ucm.DisplayControl(MainForm.menuControl);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MainForm.ucm.DisplayControl(MainForm.menuControl);
        }
    }
}
