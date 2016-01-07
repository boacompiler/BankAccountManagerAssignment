namespace BankAccountManager.Classes
{
    //Honorific enum is publicly defined in this file due to it being exclusively used with the Name class, or when the name class is being used. 
    public enum Honorific
    {
        None,
        Mr,
        Master,
        Ms,
        Miss,
        Mrs,
        Dr
    }

    public class Name
    {
        private string firstName;
        private string secondName;
        //made public for serialisation compatibility
        public Honorific honorific;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                //first name cannot be empty
                if (value.Length < 1)
                {
                    throw new System.ArgumentException("Invalid first name");
                }
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
                //second name cannot be empty
                if (value.Length < 1)
                {
                    throw new System.ArgumentException("Invalid second name");
                }
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

        //Removed constructor for serialistation compatibility
        public void SetFullName(string firstName, string secondName, Honorific honorific)
        {
            FirstName = firstName;
            SecondName = secondName;
            Honorific = honorific;
        }

        //returns the name as a string in a common format
        //(Honorific) FirstName SecondName
        //if honorific is None, it is excluded from the string
        public string GetFullName()
        {
            string name = (honorific != Honorific.None) ? honorific.ToString() + " " + firstName + " " + secondName : firstName + " " + secondName;
            return name;
        }

    }
}
