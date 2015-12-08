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
        //a simple ovveride allows a numeric updown to display currency
        //the raw double is converted to currency using string formatting, so the displayed value loses precision
        protected override void UpdateEditText()
        {
            this.Text = string.Format("{0:C}",this.Value);
        }

    }
}
