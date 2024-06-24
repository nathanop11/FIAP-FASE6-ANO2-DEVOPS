namespace Fiap.Web.Alunos.Models
{
    public class ChamadasModel
    {
        public int LigacaoId { get; set; }
        public DateTime DataOcorrido { get; set; }
        public string? NumeroLigacao { get; set; }
        public int CentralId { get; set; }  // Chave estrangeira


    }
}