using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ITUtilities.Models
{
    public class isfPerson
    {
        //ID
        public int Id { get; set; }

        //Rank
        public int? RankId { get; set; }
        public virtual Rank Rank { get; set; }

        //Name
        [Required(ErrorMessage = "حقل {0} مطلوب"), DisplayName("الإسم")]
        public string Name { get; set; }
        [DisplayName("الرقم المالي / رقم الكنية")]
        public int MilitaryNumber { get; set; }

        //Active
        [DisplayName("فعال")]
        public bool Active { get; set; }

        //Branch
        [DisplayName("الفرع")]
        public int BranchId { get; set; }
        [DisplayName("الفرع")]
        public isfBranch Branch { set; get; }
    }
}