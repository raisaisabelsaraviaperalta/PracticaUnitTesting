using Xunit;
using EstudianteAPI.Controllers;
using EstudianteAPI.Models;
using EstudianteAPI.Services;

// UnitTests sin Mocks Ni Stubs, para probar que display coverage este funcionando correctamente

namespace EstudianteAPI.Controllers.UnitTests
{
    public class EstudianteServiceRealTests
    {
        [Fact]
        public void HasApproved_EstudianteNotaMayorA51_DeberiaAprobar()
        {
            // Arrange
            var estudiante = new Estudiante { Ci = 7526667, Nombre = "Raisa Saravia", Nota = 75 };
            var service = new EstudianteService();
            var controller = new EstudianteController(service);

            // Act
            var resultado = controller.HasApproved(estudiante);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void HasApproved_EstudianteNotaMenorA51_NoDeberiaAprobar()
        {
            // Arrange
            var estudiante = new Estudiante { Ci = 7526667, Nombre = "Raisa Saravia", Nota = 40 };
            var service = new EstudianteService();
            var controller = new EstudianteController(service);

            // Act
            var resultado = controller.HasApproved(estudiante);

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void HasApproved_EstudianteNotaIgualA51_DeberiaAprobar()
        {
            // Arrange
            var estudiante = new Estudiante { Ci = 7526667, Nombre = "Raisa Saravia", Nota = 51 };
            var service = new EstudianteService();
            var controller = new EstudianteController(service);

            // Act
            var resultado = controller.HasApproved(estudiante);

            // Assert
            Assert.True(resultado);
        }
    }
}
