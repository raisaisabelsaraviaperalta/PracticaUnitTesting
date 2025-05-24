using Xunit;
using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Controllers;
using EstudianteAPI.Models;
using EstudianteAPI.Tests.Utils;
using EstudianteAPI.Tests.Stubs;
using EstudianteAPI.Services;
using Moq;

//Tests de prueba Crud (Probando que funcione correctamente)

namespace EstudianteAPI.Controllers.UnitTests
{
    public class EstudianteGetMethodsTests
    {
        [Fact]
        public void GetAll_ExistingEstudiantes_WithAllEstudiantes()
        {
            var mockService = new Mock<IEstudianteService>();
            mockService.Setup(service => service.GetAll()).Returns(
                new List<Estudiante>
                {
                    new Estudiante { Ci = 7526667, Nombre = "Raisa Saravia", Nota = 85 },
                    new Estudiante { Ci = 7526666, Nombre = "Erika Saravia", Nota = 90 }
                }
            );
            // Arrange - Given
            EstudianteController controller = new EstudianteController(mockService.Object);

            // Act - When
            var result = controller.GetAll();

            // Assert - Then
            Assert.Equal(2, result.Count());
            Assert.Equal("Raisa Saravia", result[0].Nombre);
            Assert.Equal(85, result[0].Nota);
            Assert.Equal("Erika Saravia", result[1].Nombre);
            Assert.Equal(90, result[1].Nota);
        }


        [Fact]
        public void GetByCi_ExistingCi_ReturnsEstudiante()
        {
            // Arrange - Given
            EstudianteController controller = new EstudianteController(new EstudianteServiceStub());
            int estudianteCi = 7526667;

            // Act - When
            var result = controller.GetByCi(estudianteCi);

            // Assert - Then
            Assert.NotNull(result);
            Assert.Equal(estudianteCi, result.Ci);
            Assert.Equal("Estudiante Name", result.Nombre);
            Assert.Equal(85, result.Nota);
        }


        [Fact]
        public void GetByCi_NonExistingCi_ReturnsNull()
        {
            // Arrange - Given
            EstudianteService estudianteService = new EstudianteService();
            estudianteService.Create(new Estudiante { Ci = 7526667, Nombre = "Raisa Saravia", Nota = 85 });
            estudianteService.Create(new Estudiante { Ci = 7526666, Nombre = "Erika Saravia", Nota = 90 });
            EstudianteController controller = new EstudianteController(estudianteService);
            int estudianteCi = 7526668;

            // Act - When
            Estudiante result = controller.GetByCi(estudianteCi);

            Console.WriteLine("Estudiante Ci: " + result.Ci);
            Console.WriteLine($"Estudiante Name: {result.Nombre}");

            // Assert - Then
            Assert.NotNull(result);
            Assert.Equal(-1, result.Ci);
            Assert.Equal("Estudiante Name", result.Nombre);
        }
    }
}
