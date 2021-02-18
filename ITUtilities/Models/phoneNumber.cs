using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITUtilities.Models
{
    public class phoneNumber
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Nb1")]
        public string Number1 { get; set; }
        [DisplayName("Nb2")]
        public string Number2 { get; set; }
        [DisplayName("Nb3")]
        public string Number3 { get; set; }
        [DisplayName("Nb4")]
        public string Number4 { get; set; }
        [DisplayName("Nb5")]
        public string Number5 { get; set; }
        [DisplayName("External")]
        public string ExternalNumber { get; set; }
        [DisplayName("Order")]
        public int Order { get; set; }
        [Required]
        public int isfBranchId { get; set; }
        public isfBranch Branch { get; set; }
        public virtual ICollection<isfPerson> sss { get; set; }

    }
}