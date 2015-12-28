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
    public partial class UserControlAdd : UserControl
    {

        private int accountNumber;
        //TODO Interest rate currrenty currency up down, shouldn't be

        private CurrentAccount cAccount;
        private SavingsAccount sAccount;
        private FixedTermAccount fAccount;

        public UserControlAdd()
        {
            InitializeComponent();
            comboBoxHonorific.DataSource = Enum.GetNames(typeof(Honorific));
            comboBoxType.DataSource = new string[] {"Current Account","Savings Account","Fixed Term Account"};//TODO sort this out

            cAccount = new CurrentAccount();
            sAccount = new SavingsAccount();
            fAccount = new FixedTermAccount();

            Random rand = new Random();
            int randNo;

            while (accountNumber == 0)
            {
                randNo = rand.Next(1000000000);
                if (!MainForm.myList.Exists(x => x.AcountNumber == randNo))
                {
                    accountNumber = randNo;
                }

            }

            labelAccountNumber.Text = "Account Number: " + accountNumber;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxType.SelectedIndex)
                {
                    default:
                    case 0:
                        cAccount.SetCustomerDetails(textBoxFirstName.Text,
                                                    textBoxSecondName.Text,
                                                    (Honorific)Enum.Parse(typeof(Honorific), comboBoxHonorific.SelectedValue.ToString(), true),
                                                    textBoxBuilding.Text,
                                                    textBoxRoad.Text,
                                                    textBoxTown.Text,
                                                    textBoxCounty.Text,
                                                    textBoxPostalCode.Text,
                                                    textBoxPhone.Text);
                        cAccount.CompanyName = textBoxCompanyName.Text;

                        cAccount.SetInitialBalance((double)numericUpDownCurrencyBalance.Value,
                                                   (double)numericUpDownCurrencyOverdraftLimit.Value,
                                                   (double)numericUpDownCurrencyOverdraftPenalty.Value);

                        cAccount.AcountNumber = accountNumber;

                        MainForm.myList.Add(cAccount);
                        break;
                    case 1:
                        sAccount.SetCustomerDetails(textBoxFirstName.Text,
                                                    textBoxSecondName.Text,
                                                    (Honorific)Enum.Parse(typeof(Honorific), comboBoxHonorific.SelectedValue.ToString(), true),
                                                    textBoxBuilding.Text,
                                                    textBoxRoad.Text,
                                                    textBoxTown.Text,
                                                    textBoxCounty.Text,
                                                    textBoxPostalCode.Text,
                                                    textBoxPhone.Text);
                        sAccount.CompanyName = textBoxCompanyName.Text;

                        sAccount.SetInitialBalance((double)numericUpDownCurrencyBalance.Value,
                                                   (double)numericUpDownInterestRate.Value);

                        sAccount.AcountNumber = accountNumber;

                        MainForm.myList.Add(sAccount);
                        break;
                    case 2:
                        fAccount.SetCustomerDetails(textBoxFirstName.Text,
                                                    textBoxSecondName.Text,
                                                    (Honorific)Enum.Parse(typeof(Honorific), comboBoxHonorific.SelectedValue.ToString(), true),
                                                    textBoxBuilding.Text,
                                                    textBoxRoad.Text,
                                                    textBoxTown.Text,
                                                    textBoxCounty.Text,
                                                    textBoxPostalCode.Text,
                                                    textBoxPhone.Text);
                        fAccount.CompanyName = textBoxCompanyName.Text;

                        fAccount.SetInitialBalance((double)numericUpDownCurrencyBalance.Value,
                                                   (double)numericUpDownCurrencyTransactionFee.Value);

                        fAccount.AcountNumber = accountNumber;

                        MainForm.myList.Add(fAccount);
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
