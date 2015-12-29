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
    public partial class UserControlView : UserControl
    {
        private Account account;

        private CurrentAccount cAccount;
        private SavingsAccount sAccount;
        private FixedTermAccount fAccount;

        public UserControlView()
        {
            InitializeComponent();
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

        public void setAccount(Account editAccount)
        {
            
            //this.accountNumber = AccountNumber;
            account = editAccount; //TODO testing

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
            labelName.Text = account.customerName.GetFullName();
            labelPhoneText.Text = account.customerPhone.Number;
            labelCompanyText.Text = (account.CompanyName != null)? account.CompanyName : null;
            //Address
            labelBuildingText.Text = account.customerAddress.Building;
            labelRoadText.Text = account.customerAddress.Road;
            labelTownText.Text = account.customerAddress.Town;
            labelCountyText.Text = account.customerAddress.County;
            labelPostalCodeText.Text = account.customerAddress.PostalCode;
            //Account Details
            labelBalanceText.Text = string.Format("{0:C}", account.AccountBalance);
            comboBoxType.SelectedItem = account.Type;
            comboBoxType.Enabled = false;
            switch (account.Type)
            {
                default:
                case "Current Account":
                    labelOverdraftLimitText.Text = string.Format("{0:C}", cAccount.OverdraftLimit);
                    labelOverdraftPenaltyText.Text = string.Format("{0:C}", cAccount.OverdraftPenalty);
                    break;
                case "Savings Account":
                    labelInterestRateText.Text = sAccount.InterestRate+"%";
                    break;
                case "Fixed Term Account":
                    labelTransactionFeeText.Text = string.Format("{0:C}", fAccount.TransactionFee);
                    break;
            }

            labelFunds.Text = "Current funds: "+ string.Format("{0:C}", account.AccountBalance);

            labelAccountNumber.Text = "Account Number: "+account.AcountNumber;
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MainForm.ucm.DisplayControl(MainForm.menuControl);
        }

        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            switch (account.Type)
            {
                default:
                case "Current Account":
                    cAccount.Deposit((double)numericUpDownCurrencyFunds.Value);
                    break;
                case "Savings Account":
                    sAccount.Deposit((double)numericUpDownCurrencyFunds.Value);
                    break;
                case "Fixed Term Account":
                    fAccount.Deposit((double)numericUpDownCurrencyFunds.Value);
                    break;
            }
            refresh();
            MainForm.myXML.Serialise(MainForm.myList);
            MainForm.menuControl.FillView();
        }

        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            try
            {
                switch (account.Type)
                {
                    default:
                    case "Current Account":
                        cAccount.Withdraw((double)numericUpDownCurrencyFunds.Value);
                        break;
                    case "Savings Account":
                        sAccount.Withdraw((double)numericUpDownCurrencyFunds.Value);
                        break;
                    case "Fixed Term Account":
                        fAccount.Withdraw((double)numericUpDownCurrencyFunds.Value);
                        break;
                }
                refresh();
                MainForm.myXML.Serialise(MainForm.myList);
                MainForm.menuControl.FillView();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error");
            }
            
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0:C}", sAccount.CalculateInterest()));
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            sAccount.AccountBalance += sAccount.CalculateInterest();
            refresh();
            MainForm.myXML.Serialise(MainForm.myList);
            MainForm.menuControl.FillView();
        }
    }
}
