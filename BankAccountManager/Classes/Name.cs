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

        //Removed constructor for serialistation compatibility
        public void SetFullName(string firstName, string secondName, Honorific honorific)
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
