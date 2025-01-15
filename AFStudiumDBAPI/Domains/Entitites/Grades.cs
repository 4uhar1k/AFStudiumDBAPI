namespace AFStudiumDBAPI.Domains.Entitites
{
    public record Grades
    {
        public int Id { get; init; }
        public int StudentId { get; init; }
        public int EventId { get; init; }
        public string Grade { get; init; }
    }
}
