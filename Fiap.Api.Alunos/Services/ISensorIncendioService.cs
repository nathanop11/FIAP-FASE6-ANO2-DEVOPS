using Fiap.Web.Alunos.Models;

namespace Fiap.Api.Alunos.Services
{
    public interface ISensorIncendioService
    {
        IEnumerable<SensorIncendioModel> GetSensoresIncendios();
        SensorIncendioModel AddSensorIncendio(SensorIncendioModel sensorIncendio);
        SensorIncendioModel ObterSensorPorId(int id);
        void AtualizarSensor(SensorIncendioModel sensorIncendio);
        void DeletarSensor(int id);

    }
}
