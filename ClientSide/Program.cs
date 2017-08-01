using System;
using Cable.Bridge;
using ServerSide;

namespace ClientSide
{
    public class Program
    {
        public static async void Main()
        {
            // resolve a static proxy
            var studentService = BridgeClient.Resolve<IStudentService>();

            // call server just by calling the function
            var students = await studentService.GetAllStudents();

            // use the results directly
            foreach (var student in students)
            {
                var name = student.Name;
                var age = DateTime.Now.Year - student.DateOfBirth.Year;
                Console.WriteLine($"{name} is {age} years old");
            }
        }
    }
}