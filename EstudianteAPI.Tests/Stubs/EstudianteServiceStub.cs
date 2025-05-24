using EstudianteAPI.Models;
using EstudianteAPI.Services;

namespace EstudianteAPI.Tests.Stubs
{
    public class EstudianteServiceStub : IEstudianteService
    {
        private List<Estudiante> _estudiantes;

        public EstudianteServiceStub()
        {
            _estudiantes = new List<Estudiante>()
            {
                new Estudiante { Ci = 7526667, Nombre = "Raisa Saravia", Nota = 85 },
                new Estudiante { Ci = 7526666, Nombre = "Erika Saravia", Nota = 90 }
            };
        }

        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }

        public Estudiante GetByCi(int ci)
        {
            return _estudiantes.FirstOrDefault(p => p.Ci == ci); ;
        }
        public Estudiante GetByNombre(string nombre)
        {
            return _estudiantes.FirstOrDefault(p => p.Nombre == nombre);
        }
        public Estudiante Create(Estudiante estudiante)
        {
            estudiante.Ci = _estudiantes.Max(p => p.Ci) + 1;
            return estudiante;
        }

        public Estudiante Update(int ci, Estudiante updatedEstudiante)
        {
            return updatedEstudiante;
        }

        public Estudiante Delete(int ci)
        {
            return _estudiantes[0];
        }
        public bool HasApproved(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }
    }
}