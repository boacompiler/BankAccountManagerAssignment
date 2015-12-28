using System.Xml.Serialization;

namespace BankAccountManager.Classes
{
    //Account is the base class of our serialised accounts
    //we must include all other types that will be serialised in our accounts
    //this allows the serialiser to store the data from othe classes as well as account and its children
    [XmlInclude(typeof(SavingsAccount))]
    [XmlInclude(typeof(CurrentAccount))]
    [XmlInclude(typeof(FixedTermAccount))]
    [XmlInclude(typeof(Name))]
    [XmlInclude(typeof(Address))]
    [XmlInclude(typeof(PhoneNumber))]
    public class Account
    {
        private int acountNumber;
        public Name customerName;
        public Address customerAddress;
        public PhoneNumber customerPhone;
        private string companyName;
        private double accountBalance;
        private string type;

        //protected double interestRate;//TODO i really dont like this, but how do iaccces muh properties 

        public Account()
        {
            //serialisation requires parameterless constructors, so all constructor code that sets values has been moved to "SetInitialBalance", this requires an extra line of code for initialisation butprovides a much more robust data management system
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

        public void SetCustomerDetails(string firstName, string secondName, Honorific honorific, string building, string road, string town, string county, string postalCode, string phoneNumber)
        {
            customerName = new Name();
            customerName.SetFullName(firstName, secondName, honorific);
            customerAddress = new Address();
            customerAddress.SetFullAddress(building,road,town,county,postalCode);
            customerPhone = new PhoneNumber();
            customerPhone.Number = phoneNumber;
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
        //TODO validation?
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
                throw new System.ArgumentException("Debit amount exceeds account balance");
            }
        }
    }
}
