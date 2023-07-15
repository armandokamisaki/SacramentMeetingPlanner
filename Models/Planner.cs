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
        [Display(Name = "President")]
        public int Member1ID { get; set; }
        [Display(Name = "Conducting")]
        public int Member2ID { get; set; }
        [Display(Name = "Opening Hymn")]
        public int Hymn1ID { get; set; }
        [Display(Name = "Invocation")]
        public int Member3ID { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public int Hymn2ID { get; set; }
        public String SpecialHymn { get; set; }
        [Display(Name = "Closing Hymn")]
        public int Hymn3ID { get; set; }
        [Display(Name = "Benediction")]
        public int Member4ID { get; set; }
        [Display(Name = "Dismissal Song")]
        public int? Hymn4ID { get; set; }

        public Member Member { get; set; }

        public Hymn Hymn { get; set; }
        public ICollection<Speaker> Speakers { get; set; }

    }
}
