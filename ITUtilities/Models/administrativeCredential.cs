using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITUtilities.Models
{
    public class administrativeCredential
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public string URL { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    }
}