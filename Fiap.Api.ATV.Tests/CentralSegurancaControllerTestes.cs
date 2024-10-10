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
    public class CentralSegurancaControllerTestes
    {
        [Fact]
        public async Task GetCentralSegurancaRetorna200Ok()
        {
            // Arrange
            var controller = new CentralSegurancaController(new CentralSegurancaService());

            // Act
            var result = controller.GetCentralSeguranca();

            // Assert
            var okResult = result.Result as OkObjectResult;
            
        }
    }
}

