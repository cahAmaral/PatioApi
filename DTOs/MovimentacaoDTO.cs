namespace PatioApi.DTOs
{
    public class MovimentacaoDTO
    {
        public int Id { get; set; }
        public int MotoId { get; set; }
        public int OperadorId { get; set; }
        public string TipoMovimentacao { get; set; }
        public DateTime DataHora { get; set; }
        public string SetorDestino { get; set; }
    }
}