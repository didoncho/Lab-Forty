using BusinessLayer;
using ServiceLayer.DTOs;

namespace ServiceLayer.Mappers;

public class FencerMapper
{
    public static Fencer ToBusiness(FencerDTO fencer)
    {
        return new Fencer()
        {
            Id = fencer.Id,
            Name = fencer.Name,
            UID =  fencer.UID,
            FencerInformation = new FencerInformation()
            {
                DateOfBirth = fencer.DateOfBirth,
                Egn = fencer.Egn,
                BirthPlace = fencer.BirthPlace,
                Address = fencer.Address
            },
            CoachId = fencer.CoachId
        };
    }
    
    public static FencerDTO ToUI(Fencer fencer)
    {
        return new FencerDTO()
        {
            Id = fencer.Id,
            Name = fencer.Name,
            DateOfBirth = fencer.FencerInformation?.DateOfBirth ?? default,
            Egn = fencer.FencerInformation?.Egn ?? string.Empty,
            BirthPlace = fencer.FencerInformation?.BirthPlace ?? string.Empty,
            Address = fencer.FencerInformation?.Address ?? string.Empty,
            CoachId = fencer.CoachId
        };
    }
    
}