using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Api.Alunos.Services
{

    public class SensorIncendioService : ISensorIncendioService
    {
        private readonly List<SensorIncendioModel> _sensoresIncendio = new List<SensorIncendioModel>();
        private readonly ISensorIncendioRepository _repositorySensor;

        public IEnumerable<SensorIncendioModel> GetSensoresIncendios()
        {
            return _sensoresIncendio;
        }
        public SensorIncendioModel ObterSensorPorId(int id) => _repositorySensor.GetById(id);
        public SensorIncendioModel AddSensorIncendio(SensorIncendioModel sensorIncendio)
        {
            _sensoresIncendio.Add(sensorIncendio);
            return sensorIncendio;
        }

        public void AtualizarSensor(SensorIncendioModel sensor) => _repositorySensor.Update(sensor);

        public void DeletarSensor(int id)
        {
            var sensor = _repositorySensor.GetById(id);
            if (sensor != null)
            {
                _repositorySensor.Delete(sensor);
            }
        }
    }

}
