using Microsoft.EntityFrameworkCore;
using PatioApi.Data;

public class MovimentacaoRepository
{
    private readonly PatioContext _context;

    public MovimentacaoRepository(PatioContext context)
    {
        _context = context;
    }

    public async Task<List<Movimentacao>> GetAllAsync()
    {
        return await _context.Movimentacoes.ToListAsync();
    }

    public async Task<Movimentacao> GetByIdAsync(int id)
    {
        return await _context.Movimentacoes.FindAsync(id);
    }

    public async Task<Movimentacao> AddAsync(Movimentacao movimentacao)
    {
        int maxId = await _context.Movimentacoes.MaxAsync(m => (int?)m.Id) ?? 0;
        movimentacao.Id = maxId + 1;

        _context.Movimentacoes.Add(movimentacao);
        await _context.SaveChangesAsync();
        return movimentacao;
    }

    public async Task UpdateAsync(Movimentacao movimentacao)
    {
        _context.Movimentacoes.Update(movimentacao);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var mov = await _context.Movimentacoes.FindAsync(id);
        if (mov != null)
        {
            _context.Movimentacoes.Remove(mov);
            await _context.SaveChangesAsync();
        }
    }
}