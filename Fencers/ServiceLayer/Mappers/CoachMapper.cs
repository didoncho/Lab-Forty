using BusinessLayer;
using ServiceLayer.DTOs;

namespace ServiceLayer.Mappers;

public static class CoachMapper
{
    public static Coach ToBusiness(CoachDTO coach)
    {
        return new Coach()
        {
            Id = coach.Id,
            Name = coach.Name,
            DateOfBirth = coach.DateOfBirth,
            Egn = coach.Egn,
            BirthPlace = coach.BirthPlace,
            Address = coach.Address
        };
    }
    
    public static CoachDTO ToUI(Coach coach)
    {
        return new CoachDTO()
        {
            Id = coach.Id,
            Name = coach.Name,
            DateOfBirth = coach.DateOfBirth,
            Egn = coach.Egn,
            BirthPlace = coach.BirthPlace,
            Address = coach.Address
        };
    }

    public static AttachCoachDTO ToAttachDTO(Coach coach)
    {
        return new AttachCoachDTO()
        {
            Id = coach.Id,
            Name = coach.Name
        };
    }
}