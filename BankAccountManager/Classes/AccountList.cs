using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Classes
{
    //TODO remove this class
    public class AccountList
    {
        private List<SavingsAccount> accounts;

        public AccountList()
        {
            accounts = new List<SavingsAccount>();
        }

        internal List<SavingsAccount> Accounts
        {
            get
            {
                return accounts;
            }

            set
            {
                accounts = value;
            }
        }
    }
}
