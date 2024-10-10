using Fiap.Api.Alunos.Controllers;
using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Controllers;
using Fiap.Web.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Api.ATV.Tests
{
    public class UserControllerTestes
    {
        [Fact]
        public async Task GetUserRetorna200Ok()
        {
            // Arrange
            var controller = new  UserController(new UserService());

            // Act
            var result = controller.GetUser();

            // Assert
            var okResult = result.Result as OkObjectResult;

        }
    }
}
