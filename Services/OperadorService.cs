using PatioApi.Models;
using PatioApi.Repositories;

namespace PatioApi.Services
{
    public class OperadorService
    {
        private readonly OperadorRepository _repo;

        public OperadorService(OperadorRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Operador>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Operador?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<Operador> AddAsync(Operador operador) => _repo.AddAsync(operador);

        public Task UpdateAsync(Operador operador) => _repo.UpdateAsync(operador);

        public Task DeleteAsync(Operador operador) => _repo.DeleteAsync(operador);

        
        public async Task DeleteByIdAsync(int id)
        {
            var operador = await _repo.GetByIdAsync(id);
            if (operador != null)
            {
                await _repo.DeleteAsync(operador);
            }
        }
    }
}