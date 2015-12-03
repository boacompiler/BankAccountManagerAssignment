namespace BankAccountManager.Classes
{
    public class SavingsAccount : Account
    {
        private double interestRate;

        public SavingsAccount()
        {
            this.Type = "Savings Account";
        }

        public void SetInitialBalance(double initialBalance, double initialInterestRate)
        {
            interestRate = initialInterestRate;
            base.SetInitialBalance(initialBalance);
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
