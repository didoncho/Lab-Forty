using DatabaseLayer;
using BusinessLayer;
using ServiceLayer.DTOs;
using ServiceLayer.Mappers;

namespace ServiceLayer;

public class FencerService(FencerRepository repository)
{
    // CREATE
    public async Task<FencerDTO> CreateFencerAsync(FencerDTO fencer)
    {
        var fencerEntity = FencerMapper.ToBusiness(fencer);
        var createdFencer = await repository.CreateAsync(fencerEntity);
        return FencerMapper.ToUI(createdFencer);    
    }
    
    // READ
    public async Task<List<FencerDTO>> GetAllFencersAsync()
    {
        var fencers = await repository.GetAllAsync();
        return fencers.Select(f => FencerMapper.ToUI(f)).ToList();
    }
    
    // UPDATE
    public Task<bool> UpdateFencerAsync(int id, string name, int UID) =>
        repository.UpdateAsync(id, name, UID);
    
    // DELETE
    public Task<bool> DeleteFencerAsync(int id) => repository.DeleteAsync(id);
}