namespace PhoneBook.Common.Models
{
    public class ContactInfoType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }
}