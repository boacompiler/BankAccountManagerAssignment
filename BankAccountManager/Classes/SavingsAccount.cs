using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Classes
{
    class SavingsAccount : Account
    {
        private double interestRate;

        public SavingsAccount (double initialBalance, double initialInterestRate) : base(initialBalance)
        {
            interestRate = initialInterestRate;
        }
        
        public double InterestRate
        {
            get
            {
                return interestRate;
            }

            set
            {
                interestRate = value;
            }
        }

        public double CalculateInterest()
        {
            //TODO is this correct? this is what the specs ask for? * time should be there right?
            return AccountBalance * interestRate;
        }
        
    }
}
