using Addressbook.Interfaces;

namespace Addressbook.Models
{
    public class Contact : IContact
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string AddressInformation { get; set; } = null!;


    }
}

