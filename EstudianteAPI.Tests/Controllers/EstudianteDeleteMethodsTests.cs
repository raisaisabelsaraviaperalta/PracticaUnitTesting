using Xunit;
using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Controllers;
using EstudianteAPI.Models;
using EstudianteAPI.Tests.Utils;
using EstudianteAPI.Services;

//Tests de prueba Crud (Probando que funcione correctamente)

namespace EstudianteAPI.Controllers.UnitTests
{
    public class EstudianteDeleteMethodsTests
    {
        [Fact]
        public void DeleteEstudiante_ExistingCi_ReturnsDeletedEstudiante()
        {
            // Arrange
            var service = new EstudianteService();
            var estudiante1 = service.Create(new Estudiante { Nombre = "Raisa Saravia", Nota = 85 });
            service.Create(new Estudiante { Nombre = "Erika Saravia", Nota = 90 });

            var controller = new EstudianteController(service);
            int estudianteCi = estudiante1.Ci;
            // Act
            var estudianteDeleted = controller.Delete(estudianteCi);
            var estudianteCount = controller.GetAll().Count();

            // Assert
            Assert.NotNull(estudianteDeleted);
            Assert.Equal(estudianteCi, estudianteDeleted.Ci);
            Assert.Equal("Raisa Saravia", estudianteDeleted.Nombre);
            Assert.Equal(85, estudianteDeleted.Nota);
            Assert.Equal(1, estudianteCount);
        }
    }
}
