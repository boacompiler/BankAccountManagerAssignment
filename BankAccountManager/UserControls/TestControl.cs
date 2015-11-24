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
    public partial class TestControl : UserControl
    {
        SavingsAccount myAcc;
        //AccountList myList;
        List<SavingsAccount> myList;
        XMLSeriliser<List<SavingsAccount>> myXML;

        public TestControl()
        {
            InitializeComponent();
            myAcc = new SavingsAccount(50, 0.4);
            myAcc.CustomerName = new Name("Roy", "Derby", Honorific.None);
            label2.Text = "" + myAcc.AccountBalance;

            //myList = new AccountList();
            //myList.Accounts.Add(myAcc);
            myList = new List<SavingsAccount>();
            myList.Add(myAcc);
            myXML = new XMLSeriliser<List<SavingsAccount>>(myList);
            //myXML = new XMLSeriliser<AccountList>(myList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myXML.Serialise();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //myXML.Deserialise(myList);
            //label2.Text = "" + myList.Accounts[0].AccountBalance;
        }
    }
}
