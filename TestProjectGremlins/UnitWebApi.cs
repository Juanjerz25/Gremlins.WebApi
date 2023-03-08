using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.Controllers;
using Gremlins.WebApi.DataAccess.Repositories.Contracts;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestProjectGremlins
{
    [TestClass]
    public class UnitWebApi
    {
        private const string BaseUrl = "http://localhost:1234/api/";
        private readonly HttpClient client = new HttpClient();
        [TestMethod]
        public void TestMethod1()
        {
            Gremlins.WebApi.WeatherForecast weatherForecast = new Gremlins.WebApi.WeatherForecast();
            string result = weatherForecast.TemperatureC.ToString();
            Assert.AreEqual("0", result);
        }
        
        [TestMethod]
        public void TestServicioWebClientes()
        {
            // Crear una instancia del objeto Mock para la interfaz de aplicación
            var mockApp = new Mock<IClientesApplication>();
            int id_cliente = 2;

            // Configurar el método GetClientById de la interfaz de aplicación para devolver un cliente de prueba
            var client = new ClientesDto { IdCliente = 1, NombreCompleto = "John", TipoDocumento = "CC", Telefono = 31647 };
            mockApp.Setup(m => m.GetClientesForDocument(id_cliente)).Returns(new ResponseQuery<ClientesDto> { Result = client });

            // Crear una instancia del controlador del servicio web y pasarle la interfaz de aplicación como parámetro
            var controller = new ClientesController(mockApp.Object);

            // Llamar al método GetClientById del controlador
            var result = controller.GetClientesForDocument(id_cliente).Result?.Result;
            Assert.IsNotNull(result);

            // Verificar que el resultado es del tipo esperado
            Assert.IsInstanceOfType(result, typeof(ClientesDto));

            // Verificar que los valores devueltos son correctos
            //var response = (ClientesDto)result;
            Assert.AreEqual(result.IdCliente, client.IdCliente);
            Assert.AreEqual(result.NombreCompleto, client.NombreCompleto);
        }
    }
}
