using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactCrud.Models
{
    public class Contact
    {
        public int IdContact { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}