using PatioApi.Models;

public class MotoService
{
    private readonly MotoRepository _repository;

    public MotoService(MotoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Moto>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Moto?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Moto> AddAsync(Moto moto)
    {
        int maxId = await _repository.GetMaxIdAsync();
        moto.Id = maxId + 1;

        await _repository.AddAsync(moto);
        return moto;
    }

    public async Task UpdateAsync(Moto moto) => await _repository.UpdateAsync(moto);

    public async Task DeleteAsync(int id)
    {
        var moto = await _repository.GetByIdAsync(id);
        if (moto != null)
            await _repository.DeleteAsync(moto);
    }
}