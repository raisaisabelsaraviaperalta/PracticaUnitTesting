using Xunit;
using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Controllers;
using EstudianteAPI.Models;
using EstudianteAPI.Tests.Utils;
using EstudianteAPI.Services;

//Tests de prueba Crud (Probando que funcione correctamente)

namespace EstudianteAPI.Controllers.UnitTests
{
    public class EstudiantePostMethodsTests
    {
        // Unit Test
        [Fact]
        public void CreateEstudiante_ValidData_ReturnsEstudiante()
        {
            // Arrange - Given
            EstudianteController controller = EstudianteUtils.GetTestEstudianteControllerStub();
            Estudiante newEstudiante = new Estudiante { Nombre = "Juan Perez", Nota = 10 };

            // Act - When
            Estudiante createdEstudiante = controller.Create(newEstudiante);

            // Assert - Then
            Assert.NotNull(createdEstudiante);
            Assert.Equal(newEstudiante.Nombre, createdEstudiante.Nombre);
            Assert.Equal(newEstudiante.Nota, createdEstudiante.Nota);
            Assert.Equal(7526668, createdEstudiante.Ci);
        }

    }
}
