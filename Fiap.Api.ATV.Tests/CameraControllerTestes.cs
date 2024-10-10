using Fiap.Api.Alunos.Controllers;
using Fiap.Api.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Api.ATV.Tests
{
    public class CameraControllerTestes
    {
        [Fact]
        public async Task GetCameraRetorna200Ok()
        {
            // Arrange
            var controller = new CamerasController(new CameraService());

            // Act
            var result = controller.GetCameras();

            // Assert
            var okResult = result.Result as OkObjectResult;

        }
    }
}
