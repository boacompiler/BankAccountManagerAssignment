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
        TestControl testControl;
        UserControlSearch searchControl;
        UserControlManager ucm;

        public MainForm()
        {
            InitializeComponent();
            testControl = new TestControl();
            searchControl = new UserControlSearch();
            ucm = new UserControlManager(this);

            ucm.DisplayControl(testControl);
        }
    }
}
