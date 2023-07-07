using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Planner
    {
        public int PlannerId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Display(Name = "President")]
        public int Member1ID { get; set; }  
        
        public int Member2ID { get; set; }   
        public int Hymn1ID { get; set; }  
        public int Member3ID { get; set; }
        public int Hymn2ID { get; set; }
        public int? Speaker1ID { get; set; }
        public int? Speaker2ID { get;set; }

        public int? Speaker3ID { get; set; }
        public String? SpecialHymn { get; set; }
        [Display(Name = "Last Speaker")]
        public int? Speaker4ID { get; set; }
        public int Hymn3ID { get; set; }  
        public int Member4ID { get; set; }  
        public int? Hymn4ID { get; set; }

        public Member Member { get; set; }

        public Hymn Hymn { get; set; }
        public Speaker Speaker { get; set; }    

    }
}
