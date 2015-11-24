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
        List<SavingsAccount> myList;
        XMLSeriliser<List<SavingsAccount>> myXML;

        public TestControl()
        {
            InitializeComponent();
            myAcc = new SavingsAccount();
            myAcc.SetInitialBalance(100,0.2);
            myList = new List<SavingsAccount>();
            myList.Add(myAcc);
            myXML = new XMLSeriliser<List<SavingsAccount>>(myList);
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
            label1.Text = myList[0].AccountBalance + "";
        }
    }
}
