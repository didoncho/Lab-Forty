using DatabaseLayer;
using BusinessLayer;

namespace ServiceLayer;

public class FencerInformationService(FencerInformationRepository repository)
{
    // CREATE
    public Task<FencerInformation> CreateFencerInformationAsync(FencerInformation fencerInformation) => repository.CreateAsync(fencerInformation);
    
    // READ
    public Task<List<FencerInformation>> GetAllFencerInformationsAsync() => repository.GetAllAsync();
    
    // UPDATE
    public Task<bool> UpdateFencerInformationAsync(int id, DateOnly dateOfBirth,  string egn, string birthPlace, string address) =>
        repository.UpdateAsync(id, dateOfBirth, egn, birthPlace, address);
    
    // DELETE
    public Task<bool> DeleteFencerInformationAsync(int id) => repository.DeleteAsync(id);
}