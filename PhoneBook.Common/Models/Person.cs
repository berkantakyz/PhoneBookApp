namespace PhoneBook.Common.Models
{
    public class Person
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Company { get; protected set; }
        public List<ContactInfo> ContactInfos { get; protected set; }

        public Person SetBaseInformation(string firstName, string lastName, string company)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;

            return this;
        }

        public Person SetId(Guid id)
        {
            Id = id;

            return this;
        }
    }
}