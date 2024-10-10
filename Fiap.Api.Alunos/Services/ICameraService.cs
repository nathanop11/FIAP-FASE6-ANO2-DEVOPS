using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Models;
using System;

namespace Fiap.Api.Alunos.Services
{
    public interface ICameraService
    {
        IEnumerable<CameraSegurancaModel> GetCameras();
        CameraSegurancaModel AddCamera(CameraSegurancaModel camera);
        CameraSegurancaModel ObterCameraPorId(int id);
        void AtualizarCamera(CameraSegurancaModel camera);
        void DeletarCamera(int id);
    }
}