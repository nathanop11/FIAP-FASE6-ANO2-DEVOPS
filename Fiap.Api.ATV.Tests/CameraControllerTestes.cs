using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Fiap.Api.ATV.Tests
{
    [Binding]
    public class CameraControllerSteps
    {
        private HttpClient _client;
        private HttpResponseMessage _response;

        [Given(@"a API está disponível")]
        public void GivenAApiEstaDisponivel()
        {
            _client = new HttpClient(); // configurar client conforme necessário
        }

        [Given(@"a câmera com ID (.*) existe")]
        public void GivenACameraComIDExiste(int id)
        {
            // Simular a existência da câmera ou configurar dados de teste no banco de dados
        }

        [Given(@"a câmera com ID (.*) não existe")]
        public void GivenACameraComIDNaoExiste(int id)
        {
            // Configuração para câmera inexistente, ou use um ID improvável
        }

        [When(@"o usuário requisita a lista de câmeras")]
        public async Task WhenOUsuarioRequisitaAListaDeCameras()
        {
            _response = await _client.GetAsync("api/cameras");
        }

        [When(@"o usuário requisita a câmera com ID (.*)")]
        public async Task WhenOUsuarioRequisitaACameraComID(int id)
        {
            _response = await _client.GetAsync($"api/cameras/{id}");
        }

        [Then(@"o status da resposta deve ser (.*)")]
        public void ThenOStatusDaRespostaDeveSer(int statusCode)
        {
            NUnit.Framework.Assert.AreEqual((HttpStatusCode)statusCode, _response.StatusCode);
        }

        [Then(@"o corpo da resposta deve conter uma lista de câmeras")]
        public async Task ThenOCorpoDaRespostaDeveConterUmaListaDeCameras()
        {
            var content = await _response.Content.ReadAsStringAsync();
            NUnit.Framework.Assert.IsTrue(content.Contains("cameras")); // ajuste para validar o JSON esperado
        }

        [Then(@"o corpo da resposta deve conter as informações da câmera com ID (.*)")]
        public async Task ThenOCorpoDaRespostaDeveConterAsInformacoesDaCameraComID(int id)
        {
            var content = await _response.Content.ReadAsStringAsync();
            NUnit.Framework.Assert.IsTrue(content.Contains($"\"id\":{id}"));
        }

        [Then(@"o corpo da resposta deve conter uma mensagem de erro")]
        public async Task ThenOCorpoDaRespostaDeveConterUmaMensagemDeErro()
        {
            var content = await _response.Content.ReadAsStringAsync();
            NUnit.Framework.Assert.IsTrue(content.Contains("erro"));
        }
    }
}
