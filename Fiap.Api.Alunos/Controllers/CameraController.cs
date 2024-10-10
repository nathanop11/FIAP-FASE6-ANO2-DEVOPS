
using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Fiap.Api.Alunos.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CamerasController : ControllerBase
    {
        public readonly ICameraService _cameraService;

        public CamerasController(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }

        [HttpGet]
        [Authorize(Roles = "usuario, operador")]
        public ActionResult<IEnumerable<CameraSegurancaModel>> GetCameras(int pagina = 1, int paginaSize = 4)
        {
            var cameras = _cameraService.GetCameras();
            var paginaCamera = cameras.Skip((pagina - 1) * paginaSize).Take(paginaSize);
            return Ok(paginaCamera);
        }

        [HttpPost]
        [Authorize(Roles = "usuario, operador")]
        public ActionResult<CameraSegurancaModel> AddCamera(CameraSegurancaModel camera)
        {
            var addedCamera = _cameraService.AddCamera(camera);
            return CreatedAtAction(nameof(GetCameras), new { id = addedCamera.CameraId }, addedCamera);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult UpdateCamera(int id, [FromBody] CameraSegurancaModel camera)
        {
            try
            {
                var existingCamera = _cameraService;
                if (existingCamera == null)
                    return NotFound();

                camera.CameraId = id;
                _cameraService.AtualizarCamera(camera);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult DeleteCamera(int id)
        {
            try
            {
                var existingCamera = _cameraService.ObterCameraPorId(id);
                if (existingCamera == null)
                    return NotFound();

                _cameraService.DeletarCamera(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "usuario, operador")]
        public IActionResult GetCameraById(int id)
        {
            try
            {
                var camera = _cameraService.ObterCameraPorId(id);
                if (camera == null)
                    return NotFound();

                return Ok(camera);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
