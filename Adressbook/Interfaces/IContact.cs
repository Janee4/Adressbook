﻿namespace Addressbook.Interfaces
{
    /// <summary>
    /// Ett kontrakt som  bestämmer vad Contact klassen måste innehålla.
    /// </summary>
    public interface IContact
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string AddressInformation { get; set; }

        string ToString();
    }
}