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
        SavingsAccount myNamelessAccount;
        List<Account> myList;
        XMLSerialiser<List<Account>> myXML;

        

        public TestControl()
        {
            InitializeComponent();

            myAcc = new SavingsAccount();
            myAcc.SetInitialBalance(50,0.2);
            myAcc.SetCustomerDetails("Bob", "builder",Honorific.None,"b1","r1","t1","c1","GU2","12345678901");
            myAcc.customerPhone.Number = "123456 78910";

            myList = new List<Account>();
            myList.Add(myAcc);
            myXML = new XMLSerialiser<List<Account>>(myList);
            //myAcc = new SavingsAccount();
            //myAcc.SetInitialBalance(100,0.2);
            //myCAcc = new CurrentAccount();
            //myCAcc.SetInitialBalance(500,100);
            //myTestAcc = new Account();
            //myTestAcc.SetInitialBalance(100);
            //myNamelessAccount = new SavingsAccount();
            //myNamelessAccount.SetInitialBalance(1000000,0.2);
            
            //Name n = new Name();
            //Name n1 = new Name();
            //Name n2 = new Name();
            //n.SetFullName("Rob","Paulson",Honorific.Mr);
            //myCAcc.CustomerName = n;
            //n1.SetFullName("bob", "coolson", Honorific.Master);
            //myAcc.CustomerName = n1;
            //n2.SetFullName("dave", "smellyson", Honorific.None);
            //myTestAcc.CustomerName = n2;
            //myAcc.AcountNumber = 232;
            //Address ad = new Address();
            //ad.SetFullAddress("b1", "r1", "t1", "c1", "G1");
            //myAcc.CustomerAddress = ad;
            //myList = new List<Account>();
            //myList.Add(myAcc);
            //myList.Add(myCAcc);
            //myList.Add(myTestAcc);
            //myList.Add(myNamelessAccount);
            //myXML = new XMLSeriliser<List<Account>>(myList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myXML.Serialise(MainForm.myList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myList = myXML.Deserialise(myList);
            label1.Text = "" ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //label1.Text = myList[(int)numericUpDownGet.Value].AccountBalance + "";
            List<string> nameList =  myList.Select(C =>
            {
                try
                {
                   return C.CustomerName.GetFullName();
                }
                catch (Exception)
                {
                    return null;
                    //throw;
                }
            }).ToList();
            MessageBox.Show(string.Join(", ", nameList.ToArray()));
            MessageBox.Show(myList[0].customerPhone.Number);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MainForm.ucm.DisplayControl(MainForm.searchControl);
            // generate xml
            MainForm.myList.Clear();
            Random r = new Random();
            string[] names = new string[] {"Lili",
                                            "Lan",
                                            "Shoshana",
                                            "Arnold",
                                            "Ariane",
                                            "Gertude",
                                            "Maragret",
                                            "Rosaline",
                                            "Christena",
                                            "Romona",
                                            "Nadine",
                                            "Melonie",
                                            "Terica",
                                            "Mikaela",
                                            "Katia",
                                            "Geraldine",
                                            "Donovan",
                                            "Leonore",
                                            "Shiela",
                                            "Claribel",
                                            "Grayce",
                                            "Terra",
                                            "Jessica",
                                            "Luisa",
                                            "Traci",
                                            "Elinore",
                                            "Jonas",
                                            "Michelle",
                                            "Denae",
                                            "Tamiko",
                                            "Edmond",
                                            "Willy",
                                            "Sonia",
                                            "Janie",
                                            "Mikki",
                                            "Madeline",
                                            "Mckinley",
                                            "Blake",
                                            "Zenobia",
                                            "Olen",
                                            "Rosario",
                                            "Jammie",
                                            "Emely",
                                            "Cruz",
                                            "Britta",
                                            "Iona",
                                            "Belinda",
                                            "Evita",
                                            "Marilee",
                                            "Rayna"};

            for (int i = 0; i < 50; i++)
            {
                switch (r.Next(0,3))
                {
                    default:
                    case 0:
                        SavingsAccount mySAcc = new SavingsAccount();
                        mySAcc.SetInitialBalance(r.Next(10,10000),r.NextDouble()* (0.8 - 0.1) + 0.1);
                        mySAcc.SetCustomerDetails(names[r.Next(0, 49)], names[r.Next(0, 49)], (Honorific)r.Next(0,6), "b1", "r1", "t1", "c1", "GU2", "12345678901");
                        mySAcc.customerPhone.Number = "123456 78910";
                        mySAcc.AcountNumber = r.Next(10000000);
                        MainForm.myList.Add(mySAcc);
                        break;
                    case 1:
                        CurrentAccount myCAcc = new CurrentAccount();
                        myCAcc.SetInitialBalance(r.Next(10,10000),r.Next(50,100),5);
                        myCAcc.SetCustomerDetails(names[r.Next(0, 49)], names[r.Next(0, 49)], (Honorific)r.Next(0,6), "b1", "r1", "t1", "c1", "GU2", "12345678901");
                        myCAcc.customerPhone.Number = "123456 78910";
                        myCAcc.AcountNumber = r.Next(10000000);
                        MainForm.myList.Add(myCAcc);
                        break;
                    case 2:
                        FixedTermAccount myFAcc = new FixedTermAccount();
                        myFAcc.SetInitialBalance(10000000);
                        myFAcc.SetCustomerDetails(names[r.Next(0, 49)], names[r.Next(0, 49)], (Honorific)r.Next(0,6), "b1", "r1", "t1", "c1", "GU2", "12345678901");
                        myFAcc.customerPhone.Number = "123456 78910";
                        myFAcc.CompanyName = names[r.Next(0, 49)] + " inc";
                        myFAcc.AcountNumber = r.Next(10000000);
                        MainForm.myList.Add(myFAcc);
                        break;
                }
            }
            //MainForm.myXML.Serialise();
            XMLSerialiser<List<Account>> myaXML;
            myaXML = new XMLSerialiser<List<Account>>(MainForm.myList);
            myaXML.Serialise(MainForm.myList);
            MessageBox.Show("done " + MainForm.myList[0].customerName.GetFullName());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm.ucm.DisplayControl(MainForm.menuControl);
        }
    }
}
