using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFStudiumDBAPI.Domain.Entities
{
    [Table("userstable")]
    public record User
    {
        [Key]
        //[Column("MatrikelNum")]
        public int MatrikelNum { get; init; }
        //[Column("Email")]
        public string Email { get; init; }
        //[Column("Password")]
        public string Password { get; init; }
        //[Column("Name")]
        public string Name { get; init; }
        //[Column("Surname")]
        public string Surname { get; init; }
        //[Column("Course")]
        public string Course { get; init; }
        //[Column("Semester")]
        public int? Semester { get; init; }
        public string Role { get; set; }

    }
}
