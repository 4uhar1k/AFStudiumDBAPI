using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFStudiumDBAPI.Domains.Entitites
{
    [Table("messagestable")]
    public record Message
    {
        [Key]
        public int MessageId { get; init; }
        public int EventId { get; init; }
        public int SendFrom { get; init; }
        public int SendTo { get; init; }
        public string MessageHeader { get; init; }
        public string MessageText { get; init; }
        public DateTime MessageTime { get; init; }
    }
}
