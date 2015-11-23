using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Honorific Honorific { get { return this.honorific; } set { this.honorific = value; } }

        public Name(string firstName, string secondName, Honorific honorific)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.honorific = honorific;
        }

    }
}
