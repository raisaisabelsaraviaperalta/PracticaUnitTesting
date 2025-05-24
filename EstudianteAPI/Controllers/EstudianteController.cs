using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace EstudianteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        // Almacenamiento en memoria (solo para demostración)
        private List<Estudiante> _estudiantes;
        public EstudianteController()
        {
            _estudiantes = new List<Estudiante>();
        }
        public void SetEstudiantesToTest(List<Estudiante> estudiantes)
        {
            _estudiantes = estudiantes;
        }
        // GET: api/Estudiante
        [HttpGet]
        public List<Estudiante> GetAll()
        {
            return _estudiantes;
        }
       
        // GET: api/Estudiante/{ci}
        [HttpGet("{ci}")]
        public Estudiante GetByCi(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Ci == ci);
            if (estudiante == null)
            {
                return new Estudiante { Ci = 0, Nombre = "Not Found", Nota = 0 };
            }
            return estudiante;
        }

        // POST: api/Estudiante
        [HttpPost]
        public Estudiante Create(Estudiante estudiante)
        {
            _estudiantes.Add(estudiante);
            return estudiante;
        }

        // PUT: api/Estudiante/{ci}
        [HttpPut("{ci}")]
        public Estudiante Update(int ci, Estudiante updatedEstudiante)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Ci == ci);
           
                estudiante.Nombre = updatedEstudiante.Nombre;
                estudiante.Nota = updatedEstudiante.Nota;
                return estudiante;
        }

        // DELETE: api/Estudiante/{ci}
        [HttpDelete("{ci}")]
        public Estudiante Delete(int ci)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Ci == ci);
            _estudiantes.Remove(estudiante);
            return estudiante;
        }
    }

}
