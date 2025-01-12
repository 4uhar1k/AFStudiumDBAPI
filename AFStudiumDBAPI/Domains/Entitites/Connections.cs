namespace AFStudiumDBAPI.Domains.Entitites
{
    public record Connections
    {
        public int Id { get; init; }
        public int StudentId { get; init; }
        public int EventId { get; init; }
        public bool IsCreatorOrHelper { get; init; }

    }
}
