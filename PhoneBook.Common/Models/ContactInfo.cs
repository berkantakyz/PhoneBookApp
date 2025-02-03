namespace PhoneBook.Common.Models
{
    public class ContactInfo
    {
        public Guid Id { get; protected set; }
        public int InfoTypeId { get; protected set; }
        public string InfoContent { get; protected set; }
        public Guid PersonId { get; protected set; }
        public Person Person { get; protected set; }
        public ContactInfoType InfoType { get; protected set; }

        public ContactInfo SetBaseInformation(int infoTypeId, string infoContent, Guid personId) 
        {
            InfoTypeId = infoTypeId; 
            InfoContent = infoContent; 
            PersonId = personId;

            return this;
        }

        public ContactInfo SetId(Guid id)
        {
            Id = id;

            return this;
        }
    }
}