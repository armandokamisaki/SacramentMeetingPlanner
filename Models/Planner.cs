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
        public string President { get; set; }
        
        public string Conducting { get; set; }
        public string OpeningHymn { get; set; }
        
        public string Invocation { get; set; }
        
        public string SacramentHymn { get; set; }
        public String SpecialHymn { get; set; }
        
        public string ClosingHymn { get; set; }
        
        public string Benediction { get; set; }
       
        public string DismissalSong { get; set; }

        public Member Member { get; set; }

        public Hymn Hymn { get; set; }
        public ICollection<Speaker> Speakers { get; set; }

    }
}
