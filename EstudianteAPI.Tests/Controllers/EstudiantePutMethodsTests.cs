using Xunit;
using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Controllers;
using EstudianteAPI.Models;
using EstudianteAPI.Tests.Utils;

//Tests de prueba Crud (Probando que funcione correctamente)

namespace EstudianteAPI.Controllers.UnitTests
{
    public class EstudiantePutMethodsTests
    {
        // Unit Test
        [Fact]
        public void UpdateEstudiante_ExistingCi_ReturnsUpdatedEstudiante()
        {
            // Arrange - Given
            EstudianteController controller = EstudianteUtils.GetTestEstudianteControllerStub();
            int estudianteCi = 7526667;
            Estudiante updatedEstudiante = new Estudiante { Ci = estudianteCi, Nombre = "Dominga Peralta", Nota = 42 };

            // Act - When
            Estudiante result = controller.Update(estudianteCi, updatedEstudiante);

            // Assert - Then
            Assert.NotNull(result);
            Assert.Equal(updatedEstudiante.Nombre, result.Nombre);
            Assert.Equal(updatedEstudiante.Nota, result.Nota);
            Assert.Equal(estudianteCi, result.Ci);
        }
    }
}
