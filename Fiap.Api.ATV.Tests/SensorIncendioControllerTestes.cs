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
    public class SensorIncendioControllerTestes
    {
        [Fact]
        public async Task GetSensorIncendioRetorna200Ok()
        {
            // Arrange
            var controller = new SensorIncendioController(new SensorIncendioService());

            // Act
            var result = controller.GetSensorIncendio();

            // Assert
            var okResult = result.Result as OkObjectResult;

        }
    }
}
