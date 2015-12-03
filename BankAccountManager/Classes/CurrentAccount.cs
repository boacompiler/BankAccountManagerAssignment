namespace BankAccountManager.Classes
{
    public class CurrentAccount : Account
    {
        private double overdraftLimit;
        private double overdraftPenalty;

        public CurrentAccount()
        {
            this.Type = "Current Account";
        }

        public void SetInitialBalance(double initialBalance, double initialOverdraftLimit)
        {
            overdraftLimit = initialOverdraftLimit;
            overdraftPenalty = 5;
            base.SetInitialBalance(initialBalance);
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
