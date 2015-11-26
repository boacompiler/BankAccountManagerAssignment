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
                postalCode = value;
            }
        }

        //TODO add validation
        public void SetFullAddress(string building, string road, string town, string county, string postalCode)
        {
            this.building = building;
            this.road = road;
            this.town = town;
            this.county = county;
            this.postalCode = postalCode;
        }

        public string GetFullAddress()
        {
            string address = building + " " + road + ", " + town + ", " + county + ". " + postalCode;
            return address;
        }

    }
}
