using System;
using System.Linq;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Models
{
    public class Services // Todos los return son VOID para no poner los return, pero al ser funciones de busqueda deberian tener un return para devolver el valor buscado.
    {
        // Buscar usuarios por email
        static public void userByEmail(string theMail)
        {
            var Users = new List<User>();

            var userByEmailList = from user in Users where user.Email == theMail select user;
        }

        // Buscar alumnos mayores de edad
        static public void legalAgeStudents()
        {
            var Students = new List<Student>();

            var legalAgeStudentList = from student in Students where student.Dob.Year < (DateTime.Now.Year - 18)  select student; // El factor mes y dia tambien tendrian que ver, pero lo hago asi para acortar.
        }

        // Buscar alumnos que tengan al menos un curso
        static public void atLeastOneCourse()
        {
            var Students = new List<Student>();

            var oneCourseStudentList = from student in Students where student.Courses.Count > 0 select student;
        }

        // Buscar cursos de un nivel determinado que al menos tengan un alumno inscrito
        static public void courseAtLeastOneStudent(Level courseLevelToSearch)
        {
            var Courses = new List<Course>();

            var oneStudentCourseList = from course in Courses where course.Level == courseLevelToSearch && course.Students.Any() select course;
        }

        // Buscar cursos de un nivel determinado que sean de una categoría determinada
        static public void courseFromLevelAndCategory(Level levelToSearch, Category categoryToSearch)
        {
            var Courses = new List<Course>();

            var courseFromLevelAndCategoryList = from course in Courses where course.Level == levelToSearch && course.Categories == categoryToSearch select course;
        }

        // Buscar cursos sin alumnos
        static public void courseWithoutStudents()
        {
            var Courses = new List<Course>();

            var courseWithoutStudentsList = from course in Courses where course.Students.Count < 1 select course;
        }
    }
}
