namespace CarRentalApplication.Classes
{
    public class Person
    {
        public Person(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public string Name
        {
            get;
            private set;
        }

        public string PhoneNumber
        {
            get;
            private set;
        }
    }
}
