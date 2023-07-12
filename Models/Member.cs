using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacramentMeetingPlanner.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
