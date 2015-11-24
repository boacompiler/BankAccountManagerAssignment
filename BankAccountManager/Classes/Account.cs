﻿using System.Windows.Forms;

namespace BankAccountManager.Classes
{
    class Account
    {
        private int acountNumber;
        private Name customerName;
        private Address customerAddress;
        private double accountBalance;
        private double initialBalance;

        public Account(double initialBalance)
        {
            if (initialBalance < 0)
            {
                MessageBox.Show("initial balance too low");
                accountBalance = 0;
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
        //TODO kinda redundant and more of a java structure than something thats used in c#, but this is directly asked for in the specs (because specs are for c++ cough cough)
        public double GetBalance()
        {
            return accountBalance;
        }
    }
}
