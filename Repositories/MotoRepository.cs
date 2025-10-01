using Microsoft.EntityFrameworkCore;
using PatioApi.Data;
using PatioApi.Models;

public class MotoRepository
{
    private readonly PatioContext _context;

    public MotoRepository(PatioContext context)
    {
        _context = context;
    }

    public async Task<List<Moto>> GetAllAsync()
    {
        return await _context.Motos.ToListAsync();
    }

    public async Task<Moto?> GetByIdAsync(int id)
    {
        return await _context.Motos.FindAsync(id);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _context.Motos.MaxAsync(m => (int?)m.Id) ?? 0;
    }

    public async Task AddAsync(Moto moto)
    {
        _context.Motos.Add(moto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Moto moto)
    {
        _context.Motos.Update(moto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Moto moto)
    {
        _context.Motos.Remove(moto);
        await _context.SaveChangesAsync();
    }
}