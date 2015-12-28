namespace BankAccountManager.Classes
{
    public class Address
    {
        private string building;
        private string road;
        private string town;
        private string county;
        private string postalCode;

        public string Building
        {
            get
            {
                return building;
            }

            set
            {
                if (value.Length < 1)
                {
                    throw new System.ArgumentException("Invalid building");
                }
                building = value;
            }
        }

        public string Road
        {
            get
            {
                return road;
            }

            set
            {
                if (value.Length < 1)
                {
                    throw new System.ArgumentException("Invalid road");
                }
                road = value;
            }
        }

        public string Town
        {
            get
            {
                return town;
            }

            set
            {
                if (value.Length < 1)
                {
                    throw new System.ArgumentException("Invalid town");
                }
                town = value;
            }
        }

        public string County
        {
            get
            {
                return county;
            }

            set
            {
                if (value.Length < 1)
                {
                    throw new System.ArgumentException("Invalid county");
                }
                county = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }

            set
            {
                if (value.Length < 1)
                {
                    throw new System.ArgumentException("Invalid postal code");
                }
                postalCode = value;
            }
        }

        //TODO add validation
        public void SetFullAddress(string building, string road, string town, string county, string postalCode)
        {
            Building = building;
            Road = road;
            Town = town;
            County = county;
            PostalCode = postalCode;
        }

        public string GetFullAddress()
        {
            string address = building + " " + road + ", " + town + ", " + county + ". " + postalCode;
            return address;
        }

    }
}
