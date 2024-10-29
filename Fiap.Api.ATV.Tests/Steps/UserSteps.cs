using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace Fiap.Api.ATV.Tests.Steps
{
    [Binding]
    public class UserSteps
    {
        private RestClient client;
        private RestResponse response;

        public UserSteps()
        {
            client = new RestClient("http://localhost:5000/api"); // Endpoint base da API
        }

        [Given(@"que eu tenha os dados de um novo usuário")]
        public void GivenQueEuTenhaOsDadosDeUmNovoUsuario()
        {
            // Define os dados do usuário para a requisição
            var request = new RestRequest("users", Method.Post);
            request.AddJsonBody(new { nome = "Test User", email = "test@user.com" });
            response = client.Execute(request);
        }

        [When(@"eu envio uma requisição POST para ""(.*)""")]
        public void WhenEuEnvioUmaRequisicaoPOSTPara(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Post);
            response = client.Execute(request);
        }

        [Then(@"o sistema deve retornar status code (.*)")]
        public void ThenOSistemaDeveRetornarStatusCode(int expectedStatusCode)
        {
           NUnit.Framework.Assert.AreEqual(expectedStatusCode, (int)response.StatusCode);
        }

        [Then(@"o corpo da resposta deve conter o ID do novo usuário")]
        public void ThenOCorpoDaRespostaDeveConterOIDDoNovoUsuario()
        {
            var responseBody = response.Content;
            NUnit.Framework.Assert.IsTrue(responseBody.Contains("id"));
        }
    }
}
