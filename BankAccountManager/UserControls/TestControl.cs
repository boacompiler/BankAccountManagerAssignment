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
        List<Name> myList;
        XMLSeriliser<List<Name>> myXML;

        public TestControl()
        {
            InitializeComponent();
            myAcc = new SavingsAccount(50, 0.4);
            //myAcc.CustomerName = new Name("Roy", "Derby", Honorific.None);
            label2.Text = "" + myAcc.AccountBalance;

            //myList = new AccountList();
            //myList.Accounts.Add(myAcc);
            myList = new List<Name>();
            Name myName = new Name();
            myName.SetFullName("Louis","Poop",Honorific.Master);
            myList.Add(myName);
            myXML = new XMLSeriliser<List<Name>>(myList);
            //myXML = new XMLSeriliser<AccountList>(myList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myXML.Serialise();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myList = myXML.Deserialise(myList);
            label1.Text = "" ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = myList[0].GetFullName();
        }
    }
}
