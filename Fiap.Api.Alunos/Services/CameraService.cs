using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Api.Alunos.Services
{
    public class CameraService : ICameraService
    {
        private readonly List<CameraSegurancaModel> _cameras = new List<CameraSegurancaModel>();
        private readonly ICameraRepository _repositoryCamera;

        public CameraSegurancaModel ObterCameraPorId(int id) => _repositoryCamera.GetById(id);
        public IEnumerable<CameraSegurancaModel> GetCameras()
        {
            return _cameras;
        }

        public CameraSegurancaModel AddCamera(CameraSegurancaModel camera)
        {
            _cameras.Add(camera);
            return camera;
        }

        public void AtualizarCamera(CameraSegurancaModel camera) => _repositoryCamera.Update(camera);

        public void DeletarCamera(int id)
        {
            var Camera = _repositoryCamera.GetById(id);
            if (Camera != null)
            {
                _repositoryCamera.Delete(Camera);
            }
        }
    }
}