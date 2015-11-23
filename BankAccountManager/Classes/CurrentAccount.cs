using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Classes
{
    class CurrentAccount : Account
    {
        private double overdraftLimit;
        private double overdraftPenalty;

        public CurrentAccount(double initialBalance, double initialOverdraftLimit) : base(initialBalance)
        {
            overdraftLimit = initialOverdraftLimit;
            overdraftPenalty = 5;
        }

        public double OverdraftLimit
        {
            get
            {
                return overdraftLimit;
            }

            set
            {
                overdraftLimit = value;
            }
        }

        public double OverdraftPenalty
        {
            get
            {
                return overdraftPenalty;
            }

            set
            {
                overdraftPenalty = value;
            }
        }

        //TODO check this is the correct overide method: hiding
        new public void Withdraw(double withdrawAmount)
        {
            double amount = (withdrawAmount > overdraftLimit) ? withdrawAmount + overdraftPenalty : withdrawAmount;
            //TODO check this works
            base.Withdraw(amount);
        }

    }
}
