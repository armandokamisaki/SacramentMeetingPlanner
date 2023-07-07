using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Hymn #")]
        public int HymnID { get; set; }
        public string HymnName { get; set;}

        public string HymnDescription
        {
            get
            {
                return HymnName + "......#" + HymnID;
            }
        }
    }
}
