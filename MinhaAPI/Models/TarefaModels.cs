using MinhaAPI.Enus;

namespace MinhaAPI.Models
{
    public class TarefaModels
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefa Status { get;}
    }
}
