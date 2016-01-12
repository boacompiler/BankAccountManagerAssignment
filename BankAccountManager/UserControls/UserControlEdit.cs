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
        private Account account;

        private CurrentAccount cAccount;
        private SavingsAccount sAccount;
        private FixedTermAccount fAccount;

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

        public void setAccount(Account editAccount)
        {
            account = editAccount; 

            switch (account.Type)
            {
                default:
                case "Current Account":
                    cAccount = (CurrentAccount)account;
                    break;
                case "Savings Account":
                    sAccount = (SavingsAccount)account;
                    break;
                case "Fixed Term Account":
                    fAccount = (FixedTermAccount)account;
                    break;
            }

            refresh();
            
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
            comboBoxType.Enabled = false;
            switch (account.Type)
            {
                default:
                case "Current Account":
                    numericUpDownCurrencyOverdraftLimit.Value = (decimal)cAccount.OverdraftLimit;
                    numericUpDownCurrencyOverdraftPenalty.Value = (decimal)cAccount.OverdraftPenalty;
                    break;
                case "Savings Account":
                    numericUpDownInterestRate.Value = (decimal)sAccount.InterestRate;
                    break;
                case "Fixed Term Account":
                    numericUpDownCurrencyTransactionFee.Value = (decimal)fAccount.TransactionFee;
                    break;
            }
            labelAccountNumber.Text = "Account Number: "+account.AcountNumber;
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Customer Details
                account.customerName.honorific = (Honorific)Enum.Parse(typeof(Honorific), comboBoxHonorific.SelectedValue.ToString(), true);
                account.customerName.FirstName = textBoxFirstName.Text;
                account.customerName.SecondName = textBoxSecondName.Text;
                account.customerPhone.Number = textBoxPhone.Text;
                account.CompanyName = textBoxCompanyName.Text;
                //Address
                account.customerAddress.Building = textBoxBuilding.Text;
                account.customerAddress.Road = textBoxRoad.Text;
                account.customerAddress.Town = textBoxTown.Text;
                account.customerAddress.County = textBoxCounty.Text;
                account.CustomerAddress.PostalCode = textBoxPostalCode.Text;
                //Account Details
                account.AccountBalance = (double)numericUpDownCurrencyBalance.Value;
                switch (account.Type)
                {
                    default:
                    case "Current Account":
                        cAccount.OverdraftLimit = (double)numericUpDownCurrencyOverdraftLimit.Value;
                        cAccount.OverdraftPenalty = (double)numericUpDownCurrencyOverdraftPenalty.Value;
                        break;
                    case "Savings Account":
                        sAccount.InterestRate = (double)numericUpDownInterestRate.Value;
                        break;
                    case "Fixed Term Account":
                        fAccount.TransactionFee = (double)numericUpDownCurrencyTransactionFee.Value;
                        break;
                }

                MainForm.myXML.Serialise(MainForm.myList);
                MainForm.menuControl.FillView();
                MainForm.ucm.DisplayControl(MainForm.menuControl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MainForm.ucm.DisplayControl(MainForm.menuControl);
        }
    }
}
