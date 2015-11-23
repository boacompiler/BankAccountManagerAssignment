using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Classes
{
    class FixedTermAccount : Account
    {
        double transactionFee;

        public FixedTermAccount(double initialBalance, double initialTransactionFee) : base(initialBalance)
        {
            transactionFee = initialTransactionFee;
        }

        public double TransactionFee
        {
            get
            {
                return transactionFee;
            }

            set
            {
                transactionFee = value;
            }
        }
        //TODO i don't understand the specifications for this method
        //public bool IsFeeCharged()
        //{

        //}

    }
}
