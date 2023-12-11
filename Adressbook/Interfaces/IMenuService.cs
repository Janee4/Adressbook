
using Addressbook.Services;

namespace Addressbook.Interfaces
{
    //skapa en Interface som hanterar utskriften av menyn, den behöver inte returnera något så därav "void"
    public interface IMenuService
    {

        //skapa en metod som sköter utskriften av menyn
        void OptionsMenu();


    }
}
