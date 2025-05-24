using Xunit;
using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Controllers;
using EstudianteAPI.Models;
using EstudianteAPI.Tests.Utils;
using EstudianteAPI.Tests.Stubs;
using EstudianteAPI.Services;
using Moq;

//Tests solicitados en Práctica Final aplicando stubs

namespace EstudianteAPI.Controllers.UnitTests
{
    public class EstudianteHasApprovedTestsStubs
    {
        // Se hizo uso de Stub para simular el comportamiento del servicio
        // En este Fact se prueba que si la nota es igual a 51, el estudiante aprueba
       
        [Fact]
        public void HasApproved_EstudianteConNotaIgualA51_RetornaTrueStubs()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                Ci = 7526667,
                Nombre = "Raisa Saravia",
                Nota = 51
            };
            var stubService = new EstudianteServiceStub();
            var controller = new EstudianteController(stubService);

            //Act
            var result = controller.HasApproved(estudiante);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void HasApproved_EstudianteConNotaMayorA51_RetornaTrueStubs()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                Ci = 7526667,
                Nombre = "Raisa Saravia",
                Nota = 85
            };
            var stubService = new EstudianteServiceStub();
            var controller = new EstudianteController(stubService);

            //Act
            var result = controller.HasApproved(estudiante);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void HasApproved_EstudianteConNotaMenorA51_RetornaFalseStubs()
        {
            // Arrange
            var estudiante = new Estudiante
            {
                Ci = 7526667,
                Nombre = "Raisa Saravia",
                Nota = 45
            };
            var stubService = new EstudianteServiceStub();
            var controller = new EstudianteController(stubService);

            //Act
            var result = controller.HasApproved(estudiante);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void NombreDelEstudiante_DebeSerComoSeIngresoStubs()
        {
            // Arrange
            var nombreEsperado = "Raisa Saravia";
            var stubService = new EstudianteServiceStub();
            var controller = new EstudianteController(stubService);

            //Act
            var resultado = controller.GetByNombre(nombreEsperado);

            //Assert
            Assert.Equal(nombreEsperado, resultado.Nombre);
        }

        [Fact]
        public void CiDelEstudiante_DebeSerIngresadoStubs()
        {
            // Arrange
            var ciEsperado = 7526667;
            var stubService = new EstudianteServiceStub();
            var controller = new EstudianteController(stubService);

            //Act
            var resultado = controller.GetByCi(ciEsperado);

            //Assert
            Assert.Equal(ciEsperado, resultado.Ci);
        }

    }
}
