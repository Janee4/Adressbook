using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adressbook.Interfaces;

namespace Adressbook.Models
{
    public class Person : IPerson
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string AdressInformation { get; set; } = null!;


    }
}

