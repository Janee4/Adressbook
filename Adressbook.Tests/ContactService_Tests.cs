using Addressbook.Interfaces;
using Addressbook.Models;
using Addressbook.Services;

namespace Adressbook.Tests
{
    public class ContactService_Tests
    {
        [Fact]
        public void AddContactShould_AddOneContactToContactList_ThenReturnTrue()
        {
            //Arrange
            IContact contact = new Contact { FirstName = "Jane", LastName = "Aban", PhoneNumber = "073-1234567", Email = "Jane@domain.com", AddressInformation = "Privatavägen 30265" };
            IContactService contactService = new ContactService();

            //Act (vad för resultat vi förväntar oss)
            bool result = contactService.AddContact(contact);

            //Assert (om vår metod fungerar, så förväntar true värde returneras)
            Assert.True(result);
        }

        [Fact]

        public void RemoveContactShould_RemoveOneContactFromContactList_ThenReturnTrue()
        {
            //Arrange
            //Vi skapar först en kontakt och kallar den för "contactToRemove" 
            IContact contactToRemove = new Contact
            {
                FirstName = "Jane",
                LastName = "Aban",
                PhoneNumber = "073-1234567",
                Email = "Jane@domain.com",
                AddressInformation = "Privatavägen 30265"
            };

            //Sen skapar vi en instans av IContactService där metoden RemoveContact finns:
            IContactService contactService = new ContactService();
            //Nu lägger vi till kontakten "contactToRemove" i listan som finns i contactService med hjälp av AddContact metoden vi redan skapat (och som fungerar).
            contactService.AddContact(contactToRemove);


            //Act
            //Här tar vi bort kontakten från listan med den angivna emailAdressen
            bool result = contactService.RemoveContact(contactToRemove.Email);

            //Assert
            //Vi förväntar oss att om kontakten tas bort så returneras true
            Assert.True(result);
   
        }

        [Fact]
        public void GetContactShould_ReturnExistingContactFromContactList_AndReturnTrue()
        {

            //Arrange
            IContact expectedContact = new Contact
            {
                FirstName = "Jane",
                LastName = "Aban",
                PhoneNumber = "073-1234567",
                Email = "Jane@domain.com",
                AddressInformation = "Privatavägen 30265"
            };
            IContactService contactService = new ContactService();
            contactService.AddContact(expectedContact);

            //Act
            IContact result = contactService.GetContact(expectedContact.Email);


            //Assert
            Assert.NotNull(result); // Verifiera att det returnerade resultatet inte är null
            Assert.Equal(expectedContact.Email, result.Email); // Verifiera att e-postadresserna matchar
        }




        [Fact]
        public void GetAllContactsShould_GetAllContactsThatAreSavedInTheList_ThenReturnListOfContacts()
        {
            //Arrange
            IContactService contactService = new ContactService();
            IContact contact = new Contact { FirstName = "", LastName = "", PhoneNumber = "", Email = "", AddressInformation = "" };
            contactService.AddContact(contact);

            //Act (Vi anropar GetAllContacts metoden och sparar in det som returneras av metoden till result)
            IEnumerable<IContact> result = contactService.GetAllContacts();
            
            //Assert
            //Förväntar oss att resultatet inte är null
            Assert.NotNull(result);
            //IsAssignableFrom är en metod som testar om objekten i listan (kontakterna) är av typen IContact/eller av dess subtyper och då kommer testet att passera:
            Assert.IsAssignableFrom<IEnumerable<IContact>>(result);
        }



    }
}
