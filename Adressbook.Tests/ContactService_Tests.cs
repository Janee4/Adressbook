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
            IContact contact = new Contact { FirstName = "", LastName = "", PhoneNumber = "", Email = "", AddressInformation = "" };
            IContactService contactService = new ContactService();

            //Act (vad för resultat vi förväntar oss)
            bool result = contactService.AddContact(contact);

            //Assert (om vår metod fungerar, så förväntar true värde returneras)
            Assert.True(result);

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
