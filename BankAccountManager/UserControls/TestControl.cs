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
        CurrentAccount myCAcc;
        Account myTestAcc;
        List<Account> myList;
        XMLSeriliser<List<Account>> myXML;

        

        public TestControl()
        {
            InitializeComponent();

            

            myAcc = new SavingsAccount();
            myAcc.SetInitialBalance(100,0.2);
            myCAcc = new CurrentAccount();
            myCAcc.SetInitialBalance(500,100);
            myTestAcc = new Account();
            myTestAcc.SetInitialBalance(100);
            Name n = new Name();
            Name n1 = new Name();
            Name n2 = new Name();
            n.SetFullName("Rob","Paulson",Honorific.Mr);
            myCAcc.CustomerName = n;
            n1.SetFullName("bob", "coolson", Honorific.Master);
            myAcc.CustomerName = n1;
            n2.SetFullName("dave", "smellyson", Honorific.Miss);
            myTestAcc.CustomerName = n2;
            myAcc.AcountNumber = 232;
            Address ad = new Address();
            ad.SetFullAddress("b1", "r1", "t1", "c1", "G1");
            myAcc.CustomerAddress = ad;
            myList = new List<Account>();
            myList.Add(myAcc);
            myList.Add(myCAcc);
            myList.Add(myTestAcc);
            myXML = new XMLSeriliser<List<Account>>(myList);
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
            //label1.Text = myList[(int)numericUpDownGet.Value].AccountBalance + "";
            List<string> nameList = myList.Select(C => C.CustomerName.FirstName).ToList();
            MessageBox.Show(string.Join(", ", nameList.ToArray()));
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
