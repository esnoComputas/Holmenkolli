namespace AspireApp.WebApp.Database;

public class Position
{
    public int Id { get; set; }
    public Candidate? Candidate { get; set; }
    public int Stage {get; set;}
}