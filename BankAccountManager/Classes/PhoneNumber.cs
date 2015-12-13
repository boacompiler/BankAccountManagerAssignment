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
                double d; //we need a double to use tryparse
                value = value.Replace(" ","");//removes spaces from entered numbers

                if (value.Length > 11)
                {
                    throw new System.ArgumentException("Telephone number too long");
                }
                else if (!double.TryParse(value,out d))
                {
                    throw new System.ArgumentException("Telephone number uses invalid characters");
                }
                else
                {
                    number = value;
                }
                 
            }
        }

    }
}
