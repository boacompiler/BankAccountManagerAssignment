//using System.Windows.Forms;
using System.Xml.Serialization;

namespace BankAccountManager.Classes
{
    [XmlInclude(typeof(SavingsAccount))]
    [XmlInclude(typeof(CurrentAccount))]
    [XmlInclude(typeof(FixedTermAccount))]
    [XmlInclude(typeof(Name))]
    [XmlInclude(typeof(Address))]
    public class Account
    {
        private int acountNumber;
        public Name customerName;
        public Address customerAddress;
        private string companyName;
        private double accountBalance;
        private string type;
        //TODO phone number

        public Account()
        {
            //serialisation requires parameterless constructors, so all constructor code has been moved to "SetInitialBalance", this requires an extra line of code for initialisation butprovides a much more robust data management system
            type = "Account";
        }

        public void SetInitialBalance(double initialBalance)
        {
            if (initialBalance < 0)
            {
                //MessageBox.Show("initial balance too low");
                accountBalance = 0;
                throw new System.ArgumentException("Initial balance too low");
                //TODO is this a good time to throw exception, i don't think so?
            }
            else
            {
                accountBalance = initialBalance;
            }
            //accountBalance = (initialBalance >= 0) ? initialBalance : 0;
            //TODO clean this up, and maybe come up with a better solution, but this is directly asked for in the specs
            

        }

        public int AcountNumber
        {
            get
            {
                return acountNumber;
            }

            set
            {
                acountNumber = value;
            }
        }

        internal Name CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        internal Address CustomerAddress
        {
            get
            {
                return customerAddress;
            }

            set
            {
                customerAddress = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        //TODO this is sorta redundant due to specifications but much better than specifications...
        public double AccountBalance
        {
            get
            {
                return accountBalance;
            }

            set
            {
                accountBalance = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return companyName;
            }

            set
            {
                companyName = value;
            }
        }

        //TODO add validation
        public void Deposit(double depositAmount)
        {
            accountBalance += depositAmount;
        }

        public void Withdraw(double withdrawAmount)
        {
            if (withdrawAmount <= accountBalance)
            {
                accountBalance -= withdrawAmount;
            }
            else
            {
                //MessageBox.Show("Debit amount exceeds account balance");
                throw new System.ArgumentException("Debit amount exceeds account balance");
            }
        }
        //TODO kinda redundant and more of a java structure than something thats used in c#, but this is directly asked for in the specs (because specs are for c++ cough cough)
        public double GetBalance()
        {
            return accountBalance;
        }
    }
}
