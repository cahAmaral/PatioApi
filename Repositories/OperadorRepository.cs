using Microsoft.EntityFrameworkCore;
using PatioApi.Data;
using PatioApi.Models;

namespace PatioApi.Repositories
{
    public class OperadorRepository
    {
        private readonly PatioContext _context;

        public OperadorRepository(PatioContext context)
        {
            _context = context;
        }

        
        public async Task<List<Operador>> GetAllAsync()
        {
            return await _context.Operadores.ToListAsync();
        }
        
        public async Task<Operador?> GetByIdAsync(int id)
        {
            return await _context.Operadores.FindAsync(id);
        }
        
        public async Task<Operador> AddAsync(Operador operador)
        {
            
            int maxId = await _context.Operadores.MaxAsync(o => (int?)o.Id) ?? 0;
            operador.Id = maxId + 1;

            _context.Operadores.Add(operador);
            await _context.SaveChangesAsync();
            return operador;
        }

        
        public async Task UpdateAsync(Operador operador)
        {
            _context.Operadores.Update(operador);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(Operador operador)
        {
            _context.Operadores.Remove(operador);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteByIdAsync(int id)
        {
            var operador = await _context.Operadores.FindAsync(id);
            if (operador != null)
            {
                _context.Operadores.Remove(operador);
                await _context.SaveChangesAsync();
            }
        }
    }
}