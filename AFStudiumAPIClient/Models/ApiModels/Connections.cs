using System;
using System.Collections.Generic;
using System.Text;

namespace AFStudiumAPIClient.Models.ApiModels
{
    public class Connections
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int EventId { get; set; }
        public bool IsCreatorOrHelper { get; set; }

    }
}
