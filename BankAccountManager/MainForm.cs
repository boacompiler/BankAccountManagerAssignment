using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BankAccountManager.Classes;
using BankAccountManager.UserControls;


namespace BankAccountManager
{
    public partial class MainForm : Form
    {
        public static UserControlManager ucm;

        public static List<Account> myList;
        public static XMLSeriliser<List<Account>> myXML;

        public static TestControl testControl;
        public static UserControlSearch searchControl;
        public static UserControlMenu menuControl;
        public static UserControlEdit editControl;
        public static UserControlAdd addControl;

        public MainForm()
        {
            InitializeComponent();
            ucm = new UserControlManager(this);

            myList = new List<Account>();
            myXML = new XMLSeriliser<List<Account>>(myList);

            myList = myXML.Deserialise(myList);//TODO remove, this is for testing, or is it?

            testControl = new TestControl();
            searchControl = new UserControlSearch();
            menuControl = new UserControlMenu();
            editControl = new UserControlEdit();
            addControl = new UserControlAdd();

            ucm.DisplayControl(menuControl);
        }
    }
}
