using BusinessLayer;
using ServiceLayer.DTOs;

namespace ServiceLayer.Mappers;

public class CompetitionMapper
{
    public static Competition ToBusiness(CompetitionDTO competition)
    {
        return new Competition()
        {
            Id = competition.Id,
            Name = competition.Name,
            Date = competition.Date
        };
    }
    
    public static CompetitionDTO ToUI(Competition competition)
    {
        return new CompetitionDTO()
        {
            Id = competition.Id,
            Name = competition.Name,
            Date = competition.Date
        };
    }
}