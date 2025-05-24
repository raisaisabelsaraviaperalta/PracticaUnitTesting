using EstudianteAPI.Models;

namespace EstudianteAPI.Services
{
    public interface IEstudianteService
    {
        List<Estudiante> GetAll();
        Estudiante GetByCi(int ci);
        Estudiante GetByNombre(string nombre);
        Estudiante Create(Estudiante estudiante);
        Estudiante Update(int ci, Estudiante updatedEstudiante);
        Estudiante Delete(int ci);
        bool HasApproved(Estudiante estudiante);
        
    }
}