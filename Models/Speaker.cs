using System;
using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int SpeakerID { get; set; }        
        public int PlannerID { get; set; }
        public int MemberID { get; set; }   
        public string Topic { get; set; }
        public Member Member { get; set; }
        public Planner Planner { get; set; }
    }
}
