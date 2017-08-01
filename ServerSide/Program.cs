using System;
using Nancy;
using Nancy.Hosting.Self;
using Cable.Nancy;

namespace ServerSide
{
    public class StudentServiceModule : NancyModule
    {
        public StudentServiceModule(IStudentService service)
        {
            NancyServer.RegisterRoutesFor(this, service);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:8080")))
            {
                host.Start();
                Console.WriteLine("Server started at http://localhost:8080");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
