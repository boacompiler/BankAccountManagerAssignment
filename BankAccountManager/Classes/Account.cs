using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace BankAccountManager.Classes
{
    class Account
    {
        private int acountNumber;
        private Name customerName;
        private Address customerAddress;
        private double accountBalance;
        
        public Account(double initialBalance)
        {
            accountBalance = (initialBalance >= 0) ? initialBalance : 0;
            //TODO clean this up, and maybe come up with a better solution, but this is directly asked for in the specs
            MessageBox.Show("initial balance too low");
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
        //TODO check redundancy with the getbalance method, although this also sets
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
                MessageBox.Show("Debit amount exceeds account balance");
            }
        }
        //TODO kinda redundant and more of a java structure than something thats used in c#, but this is directly asked for in the specs
        public double GetBalance()
        {
            return accountBalance;
        }
    }
}
