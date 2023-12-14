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



            //Assert
            Assert.True(result);

        }

    }
}
