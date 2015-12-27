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
        private int accountNumber;
        private Account account;

        private CurrentAccount sAccount;

        public UserControlEdit()
        {
            InitializeComponent();
            comboBoxHonorific.DataSource = Enum.GetNames(typeof(Honorific));
            comboBoxType.DataSource = new string[] {"Current Account","Savings Account","Fixed Term Account"};//TODO sort this out

            
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
            
            this.accountNumber = AccountNumber;
            account = MainForm.myList[AccountNumber]; //TODO testing
            sAccount = (CurrentAccount)MainForm.myList[1]; //TODO THIS IS THE FIX WE NEEDED SHINY AND CHROME
            MessageBox.Show(sAccount.OverdraftLimit  +"");
        }

        public void refresh()
        {
            //Customer Details
            comboBoxHonorific.SelectedItem = account.customerName.honorific.ToString();
            textBoxFirstName.Text = account.customerName.FirstName;
            textBoxSecondName.Text = account.customerName.SecondName;
            textBoxPhone.Text = account.customerPhone.Number;
            textBoxCompanyName.Text = (account.CompanyName != null)? account.CompanyName : null;
            //Address
            textBoxBuilding.Text = account.customerAddress.Building;
            textBoxRoad.Text = account.customerAddress.Road;
            textBoxTown.Text = account.customerAddress.Town;
            textBoxCounty.Text = account.customerAddress.County;
            textBoxPostalCode.Text = account.customerAddress.PostalCode;
            //Account Details
            numericUpDownCurrencyBalance.Value = (decimal)account.AccountBalance;
            comboBoxType.SelectedItem = account.Type;

            switch (comboBoxType.SelectedIndex)
            {
                default:
                case 0:
                    //panelSavingsAccount.Hide();
                    //numericUpDownCurrencyInterestRate.Value =  ;//TODO test values
                    break;
                case 1:
                    //panelCurrentAccount.Hide();
                    break;
                case 2:
                    //panelCurrentAccount.Hide();
                    break;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //TODO enums suck and so do i, fix this
            account.customerName.FirstName = textBoxFirstName.Text;
            account.customerName.SecondName = textBoxSecondName.Text;
            account.customerPhone.Number = textBoxPhone.Text;
            account.CompanyName = textBoxCompanyName.Text;
            //TODO Address here
            account.AccountBalance = (double)numericUpDownCurrencyBalance.Value;
            //TODO type
            

            MainForm.myXML.Serialise(MainForm.myList);
            MainForm.ucm.DisplayControl(MainForm.menuControl);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MainForm.ucm.DisplayControl(MainForm.menuControl);
        }
    }
}
