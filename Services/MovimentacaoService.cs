public class MovimentacaoService
{
    private readonly MovimentacaoRepository _repository;

    public MovimentacaoService(MovimentacaoRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Movimentacao>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Movimentacao> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<Movimentacao> AddAsync(Movimentacao movimentacao) => _repository.AddAsync(movimentacao);

    public Task UpdateAsync(Movimentacao movimentacao) => _repository.UpdateAsync(movimentacao);

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}