namespace AspireApp.WebApp.Database;

public class RaceGroup
{
    public required string Name { get; set; }
    public required List<Position> Positions { get; set; }
}