using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace ServerSide
{
    public class StudentService : IStudentService
    {
        private Student[] AllStudents()
        {
            return new Student[]
            {
                new Student { Id = 0, Name = "John", Subjects = new string[] { "Math", "CS" }, DateOfBirth = new DateTime(1990, 10, 12) },
                new Student { Id = 1, Name = "Mike", Subjects = new string[] { "English" }, DateOfBirth = DateTime.Now.AddYears(-20) }
            };
        }


        public Task<IEnumerable<Student>> GetAllStudents()
        {
            IEnumerable<Student> students = AllStudents();
            return Task.FromResult(students);
        }

        public Task<Student> TryFindStudentByName(string name)
        {
            var studentSearchResult = AllStudents().FirstOrDefault(student => student.Name == name);
            return Task.FromResult(studentSearchResult);
        }
    }
}
