using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITUtilities.Models
{
    public class isfBranch
    {
        public int Id { get; set; }

        [Required, DisplayName("Branch Name")]
        //[Required(ErrorMessage = "حقل {0} مطلوب"), DisplayName("إسم الفرع")]
        public string Name { get; set; }

        [Required, DisplayName("Order")]
        //[Required(ErrorMessage = "حقل {0} مطلوب"), DisplayName("الترتيب")]
        public int OrderId { get; set; }

        //this is used in the branches tree display
        public bool isPseudo { get; set; }
        public bool Visible { get; set; } 

        public bool? IsforAdmin { get; set; }

        //[DisplayName("الفرع الذي يتبع له")]
        [DisplayName("ParentId")]
        public int? ParentId { get; set; }
        [DisplayName("Parent Branch")]
        public virtual isfBranch Parent { get; set; }

        public virtual ICollection<ctsUser> ctsUsers { get; set; }
        public virtual ICollection<phoneNumber> phoneNumbers { get; set; }
        public virtual ICollection<ipRecord> ipRecords { get; set; }

        public virtual ICollection<isfPerson> isfPeople { get; set; }
    }
}