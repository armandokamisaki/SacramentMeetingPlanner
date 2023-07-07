using System;
using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int MemberID { get; set; }   
        public string Topic { get; set; }
        public Member Member { get; set; }
    }
}
