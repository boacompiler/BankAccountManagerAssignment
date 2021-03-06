﻿using System;
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
        public static XMLSerialiser<List<Account>> myXML;

        public static UserControlMenu menuControl;
        public static UserControlEdit editControl;
        public static UserControlAdd addControl;
        public static UserControlView viewControl;

        public MainForm()
        {
            InitializeComponent();
            ucm = new UserControlManager(this);

            myList = new List<Account>();
            myXML = new XMLSerialiser<List<Account>>(myList);

            myList = myXML.Deserialise(myList);

            menuControl = new UserControlMenu();
            editControl = new UserControlEdit();
            addControl = new UserControlAdd();
            viewControl = new UserControlView();

            ucm.DisplayControl(menuControl);
        }
    }
}
