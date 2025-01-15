using System;
using System.Collections.Generic;
using System.Text;

namespace AFStudiumAPIClient.Models.ApiModels
{
    public class Grades
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int EventId { get; set; }
        public string Grade { get; set; }
    }
}
