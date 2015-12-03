﻿namespace BankAccountManager.Classes
{
    public class FixedTermAccount : Account
    {
        double transactionFee;

        public FixedTermAccount()
        {
            this.Type = "Fixed Term Account";
        }

        public void SetInitialBalance(double initialBalance, double initialTransactionFee) 
        {
            transactionFee = initialTransactionFee;
            base.SetInitialBalance(initialBalance);
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
