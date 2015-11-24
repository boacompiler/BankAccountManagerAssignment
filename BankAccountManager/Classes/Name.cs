namespace BankAccountManager.Classes
{
    enum Honorific
    {
        None,
        Mr,
        Master,
        Ms,
        Miss,
        Mrs
    }

    class Name
    {
        private string firstName;
        private string secondName;

        private Honorific honorific;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }

            set
            {
                secondName = value;
            }
        }

        internal Honorific Honorific
        {
            get
            {
                return honorific;
            }

            set
            {
                honorific = value;
            }
        }


        public Name(string firstName, string secondName, Honorific honorific)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.honorific = honorific;
        }

        public string GetFullName()
        {
            string name = (honorific != Honorific.None) ? honorific.ToString() + " " + firstName + " " + secondName : firstName + " " + secondName;
            return name;
        }

    }
}
