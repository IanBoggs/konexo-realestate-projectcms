using System;
using Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ProjectsRepository();

                Console.WriteLine (db.TestProperty);
                var con = db.ProjectContext;
                var types =con.EntityTypes;
                foreach (var type in types)
                {
                    Console.WriteLine(type.EntityTypeName);
                }
                Console.WriteLine(types.Count());

            Console.WriteLine("Complete!");
        }
    }
}
