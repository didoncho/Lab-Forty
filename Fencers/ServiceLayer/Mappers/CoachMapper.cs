using BusinessLayer;
using ServiceLayer.DTOs;

namespace ServiceLayer.Mappers;

public static class CoachMapper
{
    public static Coach ToBusiness(CoachDTO coach)
    {
        return new Coach()
        {
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
            Name = coach.Name,
            DateOfBirth = coach.DateOfBirth,
            Egn = coach.Egn,
            BirthPlace = coach.BirthPlace,
            Address = coach.Address
        };
    }
}