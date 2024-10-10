using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Alunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentralSegurancaController : ControllerBase
    {
        private readonly ICentralSegurancaService _centralSegurancaService;

        public CentralSegurancaController(ICentralSegurancaService centralSegurancaService)
        {
            _centralSegurancaService = centralSegurancaService;
        }

        [HttpGet]
        [Authorize(Roles ="usuario, operador")]
        public ActionResult<IEnumerable<CentralSegurancaModel>> GetCentralSeguranca(int pagina = 1, int paginaSize = 4)
        {
            var centraisSeguranca = _centralSegurancaService.GetCentralSeguranca();
            var paginaCentral = centraisSeguranca.Skip((pagina - 1) * paginaSize).Take(paginaSize);
            return Ok(paginaCentral);
        }

        [HttpPost]
        [Authorize(Roles = "usuario, operador")]
        public ActionResult<CentralSegurancaModel> AddSecurityCentral(CentralSegurancaModel centralSeguranca)
        {
            var addedCentral = _centralSegurancaService.AddCentralSeguranca(centralSeguranca);
            return CreatedAtAction(nameof(GetCentralSeguranca), new { id = addedCentral.CentralId }, addedCentral);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult UpdateCentral(int id, [FromBody] CentralSegurancaModel central)
        {
            try
            {
                var existingCentral = _centralSegurancaService;
                if (existingCentral == null)
                    return NotFound();

                central.CentralId = id;
                _centralSegurancaService.AtualizarCentral(central);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult DeleteCentral(int id)
        {
            try
            {
                var existingCentral = _centralSegurancaService.ObterCentralPorId(id);
                if (existingCentral == null)
                    return NotFound();

                _centralSegurancaService.DeletarCentral(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
