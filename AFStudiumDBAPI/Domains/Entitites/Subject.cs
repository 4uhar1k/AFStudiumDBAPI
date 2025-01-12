using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFStudiumDBAPI.Domains.Entitites
{
    [Table("subjectstable")]
    public record Subject
    {
        [Key]
        public int SubjectId { get; init; }
        public string SubjectName { get; init; }
        public string Faculty { get; init; }
        public int CreatedPerson { get; init; }

    }
}
