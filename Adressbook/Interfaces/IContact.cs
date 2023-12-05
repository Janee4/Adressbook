namespace Addressbook.Interfaces
{
    public interface IContact
    {
        string AdressInformation { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}