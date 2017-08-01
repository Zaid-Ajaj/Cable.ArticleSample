using Nancy;
using System;
using System.IO;
using System.Collections.Generic;


namespace ServerSide
{
    public class Resources : NancyModule
    {
        string FindClientAsset(params string[] files)
        {
            // find parent of parent of build output folder
            var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            var segments = new List<string>();
            segments.Add(projectPath);
            segments.Add("client");
            segments.AddRange(files);
            return Path.Combine(segments.ToArray());
        }

        public Resources()
        {
            // index file
            Get["/"] = args =>
            {
                var index = FindClientAsset("index.html");
                return Response.AsText(File.ReadAllText(index), "text/html");
            };

            Get["/js/{file}"] = args =>
            {
                var fileName = (string)args.file;
                var filePath = FindClientAsset("js", fileName);
                return Response.AsText(File.ReadAllText(filePath), "text/javascript");
            };
        }
    }
}
