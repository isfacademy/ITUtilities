using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITUtilities.Models
{
    public class Rank
    {
        //ID
        public int Id { get; set; }

        //Name
        public string Name { get; set; }

        //Is Officer?
        public bool IsOfficer { get; set; }

        //Order
        public int Order { get; set; }

        //People
        public virtual ICollection<isfPerson> People { get; set; }
    }
}