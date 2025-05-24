using Microsoft.AspNetCore.Mvc;
using EstudianteAPI.Models;
using EstudianteAPI.Services;

namespace EstudianteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // GET: api/Estudiante
        [HttpGet]
        public List<Estudiante> GetAll()
        {
            return _estudianteService.GetAll();
        }

        // GET: api/Estudiante/{ci}
        [HttpGet("{ci}")]
        public Estudiante GetByCi(int ci)
        {
            Estudiante estudiante = _estudianteService.GetByCi(ci);
            estudiante.Nombre = "Estudiante Name";
            return estudiante;
        }

        // GET: api/Estudiante/{nombre}
        [HttpGet("{nombre}")]
        public Estudiante GetByNombre(string nombre)
        {
            return _estudianteService.GetByNombre(nombre);  
        }

        // POST: api/Estudiante
        [HttpPost]
        public Estudiante Create(Estudiante estudiante)
        {
            return _estudianteService.Create(estudiante);
        }

        // PUT: api/Estudiante/{ci}

        [HttpPut("{ci}")]
        public Estudiante Update(int ci, Estudiante updatedEstudiante)
        {
            return _estudianteService.Update(ci, updatedEstudiante);
        }

        // DELETE: api/Estudiante/{ci}
    
        [HttpDelete("{ci}")]
        public Estudiante Delete(int ci)
        {
            return _estudianteService.Delete(ci);
        }
        //POST: api/Estudiante/HasApprove
        [HttpPost("HasApproved")]
        public bool HasApproved(Estudiante estudiante)
        {
            return _estudianteService.HasApproved(estudiante);
        }
    }
}