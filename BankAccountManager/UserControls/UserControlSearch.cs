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
    public partial class UserControlSearch : UserControl
    {
        List<Account> myList;
        XMLSeriliser<List<Account>> myXML;

        public UserControlSearch()
        {
            InitializeComponent();
            myList = new List<Account>();
            myXML = new XMLSeriliser<List<Account>>(myList);
            myList = myXML.Deserialise(myList);

            List<string> nameList = myList.Select(C =>
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

            listBox1.DataSource = nameList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedIndex+"");
        }
    }
}
