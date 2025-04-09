using AspireApp.WebApp.Components.Pages;
using AspireApp.WebApp.Database;
using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebApp.Services;

public class HolmenkollenService(HolmenkollenDbContext dbContext)
{
    public List<RaceGroup> GetRaceGroups()
    {
        return dbContext.RaceGroups.ToList();
    }

    public List<Candidate> GetCandidates()
    {
        return dbContext.Candidates.ToList();
    }
    public async Task AddCandidate(Todo.CandidateModel? candidate)
    {
        if (candidate == null)
        {
            return;
        }

        var candidateDbModel = new Candidate
        {
            Name = candidate.Name ?? "navn",
            PreferredStages = [candidate.PreferredStage ?? 0],
            RaceId = candidate.RaceId ?? 0,
            CreatedOn = DateTimeOffset.UtcNow
        };
        
        await dbContext.Candidates.AddAsync(candidateDbModel);
        await dbContext.SaveChangesAsync();
    }
}