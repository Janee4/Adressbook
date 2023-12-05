using Addressbook.Services;

namespace Adressbook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skapa en instans av "MenuService-klassen/servicen" 
            var menuService = new MenuService();
            //Anropa metoden "ShowOptionsMenu" i menuService instansen
            menuService.ShowOptionsMenu();






        }
    }
}
