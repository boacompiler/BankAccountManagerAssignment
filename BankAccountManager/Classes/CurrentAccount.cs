namespace BankAccountManager.Classes
{
    public class CurrentAccount : Account
    {
        private double overdraftLimit;
        private double overdraftPenalty;

        public CurrentAccount()
        {
            this.type = "Current Account";
        }

        public void SetInitialBalance(double initialBalance, double initialOverdraftLimit, double initialOverdraftPenalty)
        {
            overdraftLimit = initialOverdraftLimit;
            overdraftPenalty = initialOverdraftPenalty;
            base.SetInitialBalance(initialBalance);
        }
        //Getters and Setters
        public double OverdraftLimit
        {
            get
            {
                return overdraftLimit;
            }

            set
            {
                //Overdraft limit cannot be negative
                if (value >= 0)
                {
                    overdraftLimit = value;
                }
                else
                {
                    throw new System.ArgumentException("Overdraft Limit must be positive");
                }
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
                //Overdraft penalty cannot be negative
                if (value >= 0)
                {
                    overdraftPenalty = value;
                }
                else
                {
                    throw new System.ArgumentException("Overdraft Penalty must be positive");
                }
            }
        }

        //overidden withdraw method provides extra functionality
        //if the withdraw amount exceeds the overdraft limit, the sum of the overdraft penalty and withdraw amount is withdrawn
        //the final amount is withdrawn using the base withdraw method, this makes use of the existing validation
        new public void Withdraw(double withdrawAmount)
        {
            double amount = (withdrawAmount > overdraftLimit) ? withdrawAmount + overdraftPenalty : withdrawAmount;
            //uses the base classes withdraw method
            base.Withdraw(amount);
            
        }

    }
}
