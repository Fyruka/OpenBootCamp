using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICourseService
    {
        // Obtener todos los Cursos de una categoría concreta
        IEnumerable<Course> GetAllCoursesByCategory(string category);

        // Obtener todos los alumnos que no tienen cursos asociados
        IEnumerable<Course> GetAllStudentsWithNoCourses();

        // Obtener Cursos sin temarios
        IEnumerable<Course> GetAllCoursesWithoutChapters();

        // Obtener temario de un curso concreto
        IEnumerable<Course> GetChaptersFromCourse(string course);

        // Obtener alumnos de un Curso concreto
        IEnumerable<Course> GetStudentsFromCourse(string course);

        // Obtener los Cursos de un Alumno
        IEnumerable<Course> GetCoursesFromStudent(string student);
    }
}
