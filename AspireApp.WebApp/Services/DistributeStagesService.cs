using AspireApp.WebApp.Database;

namespace AspireApp.WebApp.Services;

public class DistributeStagesService
{
    public List<Position> Distribute(List<Candidate> candidates)
    {
        const int totalStages = 15;

        var assignedStages = new HashSet<int>();

        var positions = new List<Position>();

        int positionId = 1;

        foreach (var candidate in candidates)
        {
            var assignedStage = candidate.PreferredStages
                .FirstOrDefault(stage => stage <= totalStages && !assignedStages.Contains(stage));

            if (assignedStage != 0)
            {
                positions.Add(new Position
                {
                    Id = positionId++,
                    Candidate = candidate,
                    Stage = assignedStage
                });
                assignedStages.Add(assignedStage);
            }
            else
            {
                var unassignedStage = Enumerable.Range(1, totalStages)
                    .FirstOrDefault(stage => !assignedStages.Contains(stage));

                if (unassignedStage == 0)
                {
                    positions.Add(new Position
                    {
                        Id = positionId++,
                        Candidate = candidate,
                        Stage = -1
                    });
                }
                else
                {
                    positions.Add(new Position
                    {
                        Id = positionId++,
                        Candidate = candidate,
                        Stage = unassignedStage
                    });
                    assignedStages.Add(unassignedStage);
                }
            }
        }

        return positions;
    }
}