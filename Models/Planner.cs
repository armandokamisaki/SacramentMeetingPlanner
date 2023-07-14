using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Planner
    {
        public int PlannerID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string President { get; set; }
        [Display(Name = "Conducting")]
        [ForeignKey("MemberID")]
        public string Conducting { get; set; }
        [Display(Name = "Opening Hymn")]
        [ForeignKey("HymnID")]
        public int Hymn1ID { get; set; }
        public string Invocation { get; set; }
        [Display(Name = "Sacrament Hymn")]
        [ForeignKey("HymnID")]
        public int Hymn2ID { get; set; }
        public String? SpecialHymn { get; set; }
        [Display(Name = "Closing Hymn")]
        [ForeignKey("HymnID")]
        public int Hymn3ID { get; set; }
        public string Benediction{ get; set; }
        [Display(Name = "Dismissal Song")]
        [ForeignKey("HymnID")]
        public int? Hymn4ID { get; set; }

        public Member Member { get; set; }

        public Hymn Hymn { get; set; }
        public ICollection<Speaker> Speakers { get; set; }

    }
}
