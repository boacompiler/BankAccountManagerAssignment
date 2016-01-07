namespace BankAccountManager.Classes
{
    public class SavingsAccount : Account
    {
        private double interestRate;

        public SavingsAccount()
        {
            this.type = "Savings Account";
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
                //We were going to validate against negative interest, but  this does occur in some banks
                interestRate = value;
            }
        }

        //This method calculates the current interest.
        //most formula for this would involve time being multiplied as well
        //we have omitted this as it would add complexity to the solution in general and is not vital for the demonstration of OO
        //This is, however, a functional implementation of interest rate calculation, it only lacks the precison most banks would use
        public double CalculateInterest()
        {
            return AccountBalance * interestRate;
        }
        
    }
}
