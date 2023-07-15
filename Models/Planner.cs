using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Planner
    {
        public int PlannerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]        
        public string President { get; set; }
        [Required]        
        public string Conducting { get; set; }
        [Required]
        [Display(Name = "Opening Hymn")]
        public string OpeningHymn { get; set; }
        [Required]        
        public string Invocation { get; set; }
        [Required]
        [Display(Name = "Sacrament Hymn")]
        public string SacramentHymn { get; set; }
        [Display(Name = "Special Hymn")]
        public String? SpecialHymn { get; set; }
        [Required]
        [Display(Name = "Closing Hymn")]
        public string ClosingHymn { get; set; }
        [Required]

        public string Benediction { get; set; }
        [Display(Name = "Dismissal Song")]
        public string DismissalSong { get; set; }

        public Member Member { get; set; }

        public Hymn Hymn { get; set; }
        public ICollection<Speaker> Speakers { get; set; }

    }
}
