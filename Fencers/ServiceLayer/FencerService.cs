using DatabaseLayer;
using BusinessLayer;

namespace ServiceLayer;

public class FencerService(FencerRepository repository)
{
    // CREATE
    public Task<Fencer> CreateFencerAsync(Fencer fencer) => repository.CreateAsync(fencer);
    
    // READ
    public Task<List<Fencer>> GetAllFencersAsync() => repository.GetAllAsync();
    
    // UPDATE
    public Task<bool> UpdateFencerAsync(int id, string name, int UID) =>
        repository.UpdateAsync(id, name, UID);
    
    // DELETE
    public Task<bool> DeleteFencerAsync(int id) => repository.DeleteAsync(id);
}