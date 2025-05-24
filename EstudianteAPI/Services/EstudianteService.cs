using EstudianteAPI.Models;

namespace EstudianteAPI.Services
{
    public class EstudianteService : IEstudianteService
    {
        private List<Estudiante> _estudiantes;

        public EstudianteService()
        {
            _estudiantes = new List<Estudiante>();
        }

        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }

        public Estudiante GetByCi(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(p => p.Ci == ci);
            if (estudiante == null)
            {
                estudiante = new Estudiante { Ci = -1, Nombre = "Not Found", Nota = 0 };
            }
            return estudiante;
        }
        public Estudiante GetByNombre(string nombre)
        {
            var estudiante = _estudiantes.FirstOrDefault(p => p.Nombre == nombre);
            if (estudiante == null)
            {
                estudiante = new Estudiante { Ci = -1, Nombre = "Not Found", Nota = 0 };
            }
            return estudiante;
        }

        public Estudiante Create(Estudiante estudiante)
        {
            Estudiante createdEstudiante;
            if (estudiante.Nota <= 0)
            {
                createdEstudiante = new Estudiante { Ci = -1, Nombre = estudiante.Nombre + " / Nota Not Available", Nota = 0 };

            }
            else
            {
                estudiante.Ci = _estudiantes.Count > 0 ? _estudiantes.Max(p => p.Ci) + 1 : 1;
                _estudiantes.Add(estudiante);
                createdEstudiante = estudiante;
            }
            return createdEstudiante;
        }

        public Estudiante Update(int ci, Estudiante updatedEstudiante)
        {
            var estudiante = _estudiantes.FirstOrDefault(p => p.Ci == ci);

            estudiante.Nombre = updatedEstudiante.Nombre;
            estudiante.Nota = updatedEstudiante.Nota;

            return estudiante;
        }

        public Estudiante Delete(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(p => p.Ci == ci);
            _estudiantes.Remove(estudiante);
            return estudiante;
        }

        public bool HasApproved(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }
    }
}