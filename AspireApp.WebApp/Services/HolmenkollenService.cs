﻿using AspireApp.WebApp.Components.Pages;
using AspireApp.WebApp.Database;
using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebApp.Services;

public class HolmenkollenService(HolmenkollenDbContext dbContext)
{
    public List<RaceGroup> GetRaceGroups()
    {
        return dbContext.RaceGroups.ToList();
    }
    public async Task AddCandidate(Todo.CandidateModel? candidate)
    {
        if (candidate == null)
        {
            return;
        }

        var candidateDbModel = new Candidate
        {
            Name = candidate.Name!,
            PreferredStages = candidate.PreferredStages!,
            RaceId = candidate.RaceId!.Value,
            CreatedOn = DateTimeOffset.Now
        };
        
        await dbContext.Candidates.AddAsync(candidateDbModel);
        await dbContext.SaveChangesAsync();
    }
}