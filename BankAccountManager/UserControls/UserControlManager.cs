using System.Collections.Generic;
using System.Windows.Forms;

namespace BankAccountManager
{
    public class UserControlManager
    {

        private Form myForm;
        private List<UserControl> userControls;

        public Form MyForm
        {
            get
            {
                return this.myForm;
            }
            set
            {
                this.myForm = value;
            }
        }
        public List<UserControl> UserControls
        {
            get
            {
                return this.userControls;
            }
            set
            {
                this.userControls = value;
            }
        }

        /// <summary>
        /// Control switching between controls on a single form
        /// </summary>

        public UserControlManager(Form dockingForm)
        {
            this.myForm = dockingForm;
            this.userControls = new List<UserControl>();
        }

        public void DisplayControl(UserControl uControl)
        {
            if (!myForm.Controls.Contains(uControl))
            {
                myForm.Controls.Add(uControl);
            }
            foreach (Control cont in myForm.Controls)
            {
                if (cont is UserControl)
                {
                    cont.Enabled = false;
                }
            }

            uControl.Dock = DockStyle.Fill;
            uControl.Enabled = true;
            uControl.Visible = true;
            uControl.BringToFront();
        }

        public void Add(UserControl uControl)
        {
            myForm.Controls.Add(uControl);
            userControls.Add(uControl);
        }

        public void Refresh()
        {
            userControls = new List<UserControl>();
            foreach (Control cont in myForm.Controls)
            {
                if (cont is UserControl)
                {
                    userControls.Add(cont as UserControl);
                }

            }


        }
    }
}
