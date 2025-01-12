using System;
using System.Collections.Generic;
using System.Text;

namespace AFStudiumAPIClient.Models.ApiModels
{
    public class User
    {    
            
        public int MatrikelNum { get; set; }
            
        public string Email { get; set; }
            
        public string Password { get; set; }
            
        public string Name { get; set; }
            
        public string Surname { get; set; }
            
        public string Course { get; set; }
            
        public int? Semester { get; set; }
        public string Role { get; set; }
    }
}
