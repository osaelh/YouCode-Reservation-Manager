using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouCodeReservation.Data
{
    public class Student : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Count { get; set; }
    }
}
