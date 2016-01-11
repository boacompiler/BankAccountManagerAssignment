namespace BankAccountManager.Classes
{
    public class FixedTermAccount : Account
    {
        private double transactionFee;

        public FixedTermAccount()
        {
            this.type = "Fixed Term Account";
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

        public bool IsFeeCharged(int nTransaction)
        {
            bool charge = false;

            if (nTransaction > 5)
            {
                charge = true;
            }

            return charge;
        }

    }
}
