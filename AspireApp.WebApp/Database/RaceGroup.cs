namespace AspireApp.WebApp.Database;

public class RaceGroup
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required ICollection<Position> Positions { get; set; } = new List<Position>();
}