using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorIncendioController : ControllerBase
    {
        private readonly ISensorIncendioService _sensorIncendioService;

        public SensorIncendioController(ISensorIncendioService sensorIncendioService)
        {
            _sensorIncendioService = sensorIncendioService;
        }

        [HttpGet]
        [Authorize(Roles = "usuario, operador")]
        public ActionResult<IEnumerable<SensorIncendioModel>> GetSensorIncendio(int pagina = 1, int paginaSize = 4)
        {
            var sensoresIncendio = _sensorIncendioService.GetSensoresIncendios();
            var paginaSensorIncendio = sensoresIncendio.Skip((pagina - 1)  * paginaSize).Take(paginaSize);
            return Ok(paginaSensorIncendio);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult GetSensorById(int id)
        {
            try
            {
                var sensor = _sensorIncendioService.ObterSensorPorId(id);
                if (sensor == null)
                    return NotFound();

                return Ok(sensor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpPost]
        [Authorize(Roles = "usuario, operador")]
        public ActionResult<SensorIncendioModel> AddSensorIncendio(SensorIncendioModel sensorIncendio
            )
        {
            var addedSensor = _sensorIncendioService.AddSensorIncendio(sensorIncendio);
            return CreatedAtAction(nameof(GetSensorIncendio), new { id = addedSensor.SensorId }, addedSensor);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult UpdateSensor(int id, [FromBody] SensorIncendioModel sensor)
        {
            try
            {
                var existingSensor = _sensorIncendioService;
                if (existingSensor == null)
                    return NotFound();

                sensor.SensorId = id;
                _sensorIncendioService.AtualizarSensor(sensor);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult DeleteSensor(int id)
        {
            try
            {
                var existingSensor = _sensorIncendioService.ObterSensorPorId(id);
                if (existingSensor == null)
                    return NotFound();

                _sensorIncendioService.DeletarSensor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}

