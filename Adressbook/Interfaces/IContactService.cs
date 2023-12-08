﻿namespace Addressbook.Interfaces
{
    public interface IContactService

    {
        //Lägg till en kontakt i listan genom AddContact-metoden.     
        void AddContact(IContact contact);

        bool RemoveContact(string email);

        List<IContact> GetAllContacts();


    }

}
