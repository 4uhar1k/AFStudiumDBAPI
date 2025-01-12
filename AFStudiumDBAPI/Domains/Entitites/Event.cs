using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFStudiumDBAPI.Domains.Entitites
{
    [Table("eventstable")]
    public record Event
    {
        [Key]
        public int EventId { get; init; }
        public int SubjectId { get; init; }
        public string EventName { get; init; }
        public string EventType { get; init; }
        public int StudentsAmount { get; init; }
        public int CreatedPerson { get; init; }
        public string Date { get; init; }
        public string Time { get; init; }
        public int Credits { get; init; }
        public string Location { get; init; }
        public bool PermitRequired { get; init; }
        public int PermitionEvent {  get; init; }
    }
}
