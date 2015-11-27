using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace BankAccountManager.CustomControls
{
    public partial class NumericUpDownCurrency : NumericUpDown
    {

        public NumericUpDownCurrency()
        {
            
        }

        protected override void UpdateEditText()
        {
            //TODO clean
            //base.UpdateEditText();
            this.Text = string.Format("{0:C}",this.Value);
            
        }

    }
}
