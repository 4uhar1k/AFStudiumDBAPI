using System;
using System.Collections.Generic;
using System.Text;

namespace AFStudiumAPIClient.Models.ApiModels
{
    public class Event
    {
        public int EventId { get; set; }
        public int SubjectId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public int StudentsAmount { get; set; }
        public int CreatedPerson { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Credits { get; set; }
        public string Location { get; set; }
        public bool PermitRequired { get; set; }
        public int PermitionEvent { get; set; }
    }
}
