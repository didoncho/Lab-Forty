using BusinessLayer;
using ServiceLayer.DTOs;

namespace ServiceLayer.Mappers;

public class CompetitionResultMapper
{
    public static CompetitionResult ToBusiness(CompetitionResultDTO competition)
    {
        return new CompetitionResult()
        {
            Id = competition.Id,
            Rank = competition.Rank,
            Points = competition.Points
        };
    }
    
    public static CompetitionResultDTO ToUI(CompetitionResult competition)
    {
        return new CompetitionResultDTO()
        {
            Id = competition.Id,
            Rank = competition.Rank,
            Points = competition.Points
        };
    }
}