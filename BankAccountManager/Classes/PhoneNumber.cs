using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManager.Classes
{
    //a new class for phonenumbers allows verification to be handled whenever a number is input
    //the class is rudimentry but has room for expansion

    public class PhoneNumber
    {
        private String number;

        public String Number
        {
            get 
            { 
                return number; 
            }

            set 
            {
                if (value.Length > 11)
                {
                    throw new System.ArgumentException("Telephone number too long");
                }
                else
                {
                    number = value;
                }
                 
            }
        }

    }
}
