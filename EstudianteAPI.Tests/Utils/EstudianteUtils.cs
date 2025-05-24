using EstudianteAPI.Models;
using EstudianteAPI.Controllers;
using EstudianteAPI.Services;
using EstudianteAPI.Tests.Stubs;

namespace EstudianteAPI.Tests.Utils
{
    public static class EstudianteUtils
    {
        public static List<Estudiante> GetTestEstudiantes()
        {
            return new List<Estudiante>
            {
            new Estudiante { Ci = 7526667, Nombre = "Raisa Saravia", Nota = 85 },
            new Estudiante { Ci = 7526666, Nombre = "Erika Saravia", Nota = 90 }

            };
        }
         public static EstudianteController GetTestEstudianteControllerStub()
        {
            EstudianteController controller = new EstudianteController(new EstudianteServiceStub());
            return controller;
        }
    }
}