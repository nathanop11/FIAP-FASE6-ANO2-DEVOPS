namespace Fiap.Web.Alunos.Models
{
    public class CentralSegurancaModel
    {
        public int CentralId { get; set; }
        public string? CameraId { get; set; }
        public int LigarPolicia { get; set; }
        public int LigarBombeiro { get; set; }
        public int? SensorId {get; set;}
        public int UserId { get; set; }  // Chave estrangeira

        public UserModel? User {get;set;}
    }
}