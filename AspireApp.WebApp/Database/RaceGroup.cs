namespace AspireApp.WebApp.Database;

public class RaceGroup
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required List<Position> Positions { get; set; }
}