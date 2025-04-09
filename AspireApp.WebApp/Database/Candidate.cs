namespace AspireApp.WebApp.Database;

public class Candidate
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required List<int> PreferredStages {get; set;}
    public required int RaceId { get; set; }
    public required DateTimeOffset CreatedOn { get; set; }
}

