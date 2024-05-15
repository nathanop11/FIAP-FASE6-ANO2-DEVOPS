using Fiap.Web.Alunos.ViewModel;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Fiap.Web.Alunos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RepresentanteController : ControllerBase
    {
        private readonly IRepresentanteService _service;
        private readonly IMapper _mapper;

        public RepresentanteController(IRepresentanteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<RepresentanteViewModel>> Get()
        {
            var representantes = _service.ListarRepresentantes();
            var viewModelList = _mapper.Map<IEnumerable<RepresentanteViewModel>>(representantes);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<RepresentanteViewModel> Get(int id)
        {
            var representante = _service.ObterRepresentantePorId(id);
            if (representante == null)
                return NotFound();

            var viewModel = _mapper.Map<RepresentanteViewModel>(representante);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] RepresentanteViewModel viewModel)
        {
            var representante = _mapper.Map<RepresentanteModel>(viewModel);
            _service.CriarRepresentante(representante);
            return CreatedAtAction(nameof(Get), new { id = representante.RepresentanteId }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(int id, [FromBody] RepresentanteViewModel viewModel)
        {
            var representanteExistente = _service.ObterRepresentantePorId(id);
            if (representanteExistente == null)
                return NotFound();

            _mapper.Map(viewModel, representanteExistente);
            _service.AtualizarRepresentante(representanteExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(int id)
        {
            _service.DeletarRepresentante(id);
            return NoContent();
        }
    }
}
