using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerSide
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string[] Subjects { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> TryFindStudentByName(string name);
    }
}
