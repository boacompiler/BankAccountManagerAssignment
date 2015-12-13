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
    public partial class UserControlEdit : UserControl
    {
        public UserControlEdit()
        {
            InitializeComponent();
            comboBoxHonorific.DataSource = Enum.GetNames(typeof(Honorific));
            comboBoxType.DataSource = new string[] {"Current Account","Savings Account","Fixed Term Account"};
            
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {      
            switch (comboBoxType.SelectedIndex)
            {
                default:
                case 0:
                    panel2.Hide();
                    panel3.Show();
                    panel3.Dock = DockStyle.Fill;
                    break;
                case 1:
                    panel3.Hide();
                    panel2.Show();
                    panel2.Dock = DockStyle.Fill;
                    break;
            }
        }
    }
}
