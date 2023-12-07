using Addressbook.Interfaces;
using Addressbook.Models;
using Addressbook.Services;




namespace Adressbook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IContactService contactService = new ContactService();
            //Skapa en instans av "MenuService-klassen/servicen" 
            IMenuService menuService = new MenuService(contactService);
            //Anropa metoden "ShowOptionsMenu" i menuService instansen
            menuService.OptionsMenu();


        }
    }
}
