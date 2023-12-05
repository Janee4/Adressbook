namespace Adressbook.Interfaces
{
    public interface IPerson
    {
        string AdressInformation { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}