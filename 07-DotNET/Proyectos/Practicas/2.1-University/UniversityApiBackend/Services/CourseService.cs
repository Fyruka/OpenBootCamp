using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CourseService : ICourseService
    {
        public IEnumerable<Course> GetAllCoursesByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAllCoursesWithoutChapters()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAllStudentsWithNoCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetChaptersFromCourse(string course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesFromStudent(string student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetStudentsFromCourse(string course)
        {
            throw new NotImplementedException();
        }
    }
}
