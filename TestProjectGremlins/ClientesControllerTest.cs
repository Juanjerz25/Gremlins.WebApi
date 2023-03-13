using Gremlins.WebApi.Application.Contracts;
using Gremlins.WebApi.Controllers;
using Gremlins.WebApi.DTO.Clientes;
using Gremlins.WebApi.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;

namespace TestProjectGremlins
{
    [TestClass]
    public class ClientesControllerTest
    {
        private const string BaseUrl = "https://gremlinswebapi.azurewebsites.net/swagger/index.html";
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Prueba unitaria de Consulta de clientes por Id con resultado : OK
        /// </summary>
        [TestMethod]
        public void TestGetClientesByIdResultOK()
        {
            // Crear una instancia del objeto Mock para la interfaz de aplicación
            var mockApp = new Mock<IClientesApplication>();
            int id_cliente = 2;

            // Configurar el método GetClientesForDocument de la interfaz de aplicación para devolver un cliente de prueba
            var client = new ClientesDto { IdCliente = 1, NombreCompleto = "John", TipoDocumento = "CC", Telefono = 3165741984 };
            mockApp.Setup(m => m.GetClientesForDocument(id_cliente)).Returns(new ResponseQuery<ClientesDto> { Result = client });

            // Crear una instancia del controlador del servicio web y pasarle la interfaz de aplicación como parámetro
            var controller = new ClientesController(mockApp.Object);

            // Llamar al método GetClientById del controlador
            var result = controller.GetClientesForDocument(id_cliente).Result?.Result;
            Assert.IsNotNull(result);

            // Verificar que el resultado es del tipo esperado
            Assert.IsInstanceOfType(result, typeof(ClientesDto));

            // Verificar que los valores devueltos son correctos
            var response = (ClientesDto)result;
            Assert.AreEqual(result.IdCliente, client.IdCliente);
            Assert.AreEqual(result.NombreCompleto, client.NombreCompleto);
            Assert.AreEqual(result.TipoDocumento, client.TipoDocumento);
            Assert.AreEqual(result.Telefono, client.Telefono);
        }
        /// <summary>
        /// Prueba unitaria de Consulta de clientes con resultado : OK
        /// </summary>
        [TestMethod]
        public void TestGetClientesAllResultOK()
        {
            // Crear una instancia del objeto Mock para la interfaz de aplicación
            var mockApp = new Mock<IClientesApplication>();

            // Configurar el método GetClientesForDocument de la interfaz de aplicación para devolver un cliente de prueba
            var client = new ClientesDto { IdCliente = 1, NombreCompleto = "John", TipoDocumento = "CC", Telefono = 3165741984 };
            List<ClientesDto> listClientes = new List<ClientesDto>();
            listClientes.Add(client);

            mockApp.Setup(m => m.GetClientes()).Returns(new ResponseQuery<List<ClientesDto>> { Result = listClientes });

            // Crear una instancia del controlador del servicio web y pasarle la interfaz de aplicación como parámetro
            var controller = new ClientesController(mockApp.Object);

            // Llamar al método GetClientById del controlador
            var result = controller.GetClientes().Result;


            //// Verificar que los valores devueltos son correctos
            var response = (List<ClientesDto>)result.Result;
            Assert.IsInstanceOfType(response, typeof(List<ClientesDto>));
            Assert.AreEqual(true, result.Successful);

        }
        /// <summary>
        ///  Prueba unitaria de Actualizacion  de clientes con resultado : Fallido
        /// </summary>
        [TestMethod]
        public void PutClientes_Retorna_UnSuccesfull_al_pasar_un_objeto_invalido()
        {
            var mockApp = new Mock<IClientesApplication>();

            // Arrange
            var clientesController = new ClientesController(mockApp.Object);
            var clientesTest = new ClientesDto
            {
                IdCliente = 1,
                TipoDocumento = "CC",
                NumeroDocumento = "1098642222",
                // NombreCompleto = "Carlos",
                Direccion = "direccion Modificada",
                Telefono = null,
                Habilitado = true

            };
            mockApp.Setup(m => m.UpdateCliente(clientesTest)).Returns(new ResponseQuery<ClientesDto> { Result = clientesTest });

            // Añadir el error para que el ModelState.IsValid lo detecte
            // antes de añadir el registro a la BD.
            clientesController.ModelState.AddModelError("NombreCompleto", "Required");
            // Act
            var response = clientesController.ActualizarClientes(clientesTest).Result;
            // Assert
            Assert.AreEqual(false, response.Successful);
            //Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
        }
    }
}
