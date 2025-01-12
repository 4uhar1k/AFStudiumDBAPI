using System;
using System.Collections.Generic;
using System.Text;

namespace AFStudiumAPIClient.Models.ApiModels
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Faculty { get; set; }
        public int CreatedPerson { get; set; }

    }
}
