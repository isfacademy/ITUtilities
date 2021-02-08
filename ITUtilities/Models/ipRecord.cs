using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITUtilities.Models
{
    public class ipRecord
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        public string IP { get; set; }

        public int isfBranchId { get; set; }
        public isfBranch Branch { set; get; }
    }
}