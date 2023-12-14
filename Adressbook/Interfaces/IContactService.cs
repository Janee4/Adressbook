namespace Addressbook.Interfaces
{
    public interface IContactService

    {
        //Lägg till en kontakt i listan genom AddContact-metoden.     
        bool AddContact(IContact contact);

        //Borde det inte vara "emailToRemove" ist för email? 
        bool RemoveContact(string emailToRemove);

        IContact GetContact(string emailToShow);

        IEnumerable<IContact> GetAllContacts();


    }

}
