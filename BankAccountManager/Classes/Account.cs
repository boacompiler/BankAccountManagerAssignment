using System.Xml.Serialization;

namespace BankAccountManager.Classes
{
    //Account is the base class of our serialised accounts
    //we must include all other types that will be serialised in our accounts
    //this allows the serialiser to store the data from other classes as well as account and its children
    //Account is not implemented as an interface to allow generic accounts to be created and manipulated
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
        //type is used to ascertain the original account type when saved in a generic collection
        //type will not change, it is set at initialisation and has no setter, it is manipulated directly when accessed inside Account or derivative class
        //type os protected because derived classes have no access to private members in c#
        protected string type; 

        public Account()
        {
            //serialisation requires parameterless constructors, so all constructor code that sets values has been moved to "SetInitialBalance", this requires an extra line of code for initialisation but provides a much more robust data management system
            type = "Account";
        }

        public void SetInitialBalance(double initialBalance)
        {
            if (initialBalance < 0)
            {
                accountBalance = 0;
                throw new System.ArgumentException("Initial balance too low");
            }
            else
            {
                accountBalance = initialBalance;
            }
        }

        public void SetCustomerDetails(string firstName, string secondName, Honorific honorific, string building, string road, string town, string county, string postalCode, string phoneNumber)
        {
            //Each aspect of customer details is handled in a different class
            //Validation is handled within these classes
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
                //validation is handled in UserControlAdd
                //the validation is so specific to this solution that implementing it here would limit the reusability of Account
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
                //validation handled in Name
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
                //validation handled in Address
                customerAddress = value;
            }
        }
        //This will never be accessed by a customer, the can manipulate balance through withdraw/deposit
        //however this is important for general account editing purposes
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
                //In theory a company name could be anything, so no validation against content is added
                //Input validation should be handled at input
                companyName = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            //type should never change, so no setter is provided
        }
        //Method that handles depositing money into the account
        public void Deposit(double depositAmount)
        {
            //you cannot deposit negative money
            if (depositAmount >= 0)
            {
                accountBalance += depositAmount;
            }
            else
            {
                throw new System.ArgumentException("Invalid deposit");
            }
        }
        //Method that handles withdrawing money from account
        public void Withdraw(double withdrawAmount)
        {
            //you cannot withdraw negative money
            if (withdrawAmount < 0)
            {
                throw new System.ArgumentException("Invalid withdrawal");
            }
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
