using Xunit;
using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Controllers;
using EstudianteAPI.Models;
using EstudianteAPI.Tests.Utils;
using EstudianteAPI.Tests.Stubs;
using EstudianteAPI.Services;
using Moq;

//Tests solicitados en Práctica Final aplicando Moq

namespace EstudianteAPI.Controllers.UnitTests
{
    public class EstudianteHasApprovedTests
    {
        //Se hizo uso de Moq para simular el comportamiento del servicio
        // En este Fact se prueba que si la nota es igual a 51, el estudiante aprueba

        [Fact]
        public void HasApproved_EstudianteConNotaIgualA51_RetornaTrue()
        {
            var estudiante = new Estudiante
            {
                Ci = 7526667,
                Nombre = "Raisa Saravia",
                Nota = 51
            };
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(service => service.HasApproved(estudiante)).Returns(true);

            //Arrange
            var controller = new EstudianteController(mockService.Object);

            //Act
            var result = controller.HasApproved(estudiante);

            //Assert
            Assert.True(result);
        }

        //Se hizo uso de Moq para simular el comportamiento del servicio
        // En este Fact se prueba que si la nota es mayor a 51, el estudiante aprueba

        [Fact]
        public void HasApproved_EstudianteConNotaMayorA51_RetornaTrue()
        {
            var estudiante = new Estudiante
            {
                Ci = 7526667,
                Nombre = "Raisa Saravia",
                Nota = 85
            };
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(service => service.HasApproved(estudiante)).Returns(true);

            //Arrange
            var controller = new EstudianteController(mockService.Object);

            //Act
            var result = controller.HasApproved(estudiante);

            //Assert
            Assert.True(result);
        }

        //Se hizo uso de Moq para simular el comportamiento del servicio
        // En este Fact se prueba que si la nota es menor a 51, el estudiante no aprueba

        [Fact]
        public void HasApproved_EstudianteConNotaMenorA51_RetornaFalse()
        {
            var estudiante = new Estudiante
            {
                Ci = 7526667,
                Nombre = "Raisa Saravia",
                Nota = 45
            };
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(service => service.HasApproved(estudiante)).Returns(false);

            //Arrange
            var controller = new EstudianteController(mockService.Object);

            //Act
            var result = controller.HasApproved(estudiante);

            //Assert
            Assert.False(result);
        }

        //Se hizo uso de Moq para simular el comportamiento del servicio
        // En este Fact se prueba que el nombre del estudiante es el mismo que se ingreso

        [Fact]
        public void NombreDelEstudiante_DebeSerComoSeIngreso()
        {
            var nombreEsperado = "Raisa Saravia";
            var estudiante = new Estudiante
            {
                Ci = 7526667,
                Nombre = nombreEsperado,
                Nota = 85
            };
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(service => service.GetByNombre(estudiante.Nombre)).Returns(estudiante);

            //Arrange
            var controller = new EstudianteController(mockService.Object);

            //Act
            var resultado = controller.GetByNombre(nombreEsperado);

            // Assert
            Assert.Equal(nombreEsperado, resultado.Nombre);
        }

        //Se hizo uso de Moq para simular el comportamiento del servicio
        // En este Fact se prueba que el CI del estudiante es el mismo que se ingreso

        [Fact]
        public void CiDelEstudiante_DebeSerIngresado()
        {
            var ciEsperado = 7526667;
            var estudiante = new Estudiante
            {
                Ci = ciEsperado,
                Nombre = "Raisa Saravia",
                Nota = 85
            };
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(service => service.GetByCi(ciEsperado)).Returns(estudiante);

            // Arrange
            var controller = new EstudianteController(mockService.Object);

            // Act
            var resultado = controller.GetByCi(ciEsperado);

            // Assert
            Assert.Equal(ciEsperado, resultado.Ci);
        }

    }
}
