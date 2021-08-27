using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CommonObjectLibraryCore;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the new case reference");
            var caseRef = Console.ReadLine();
            Console.WriteLine("Enter The Client Name");
            var clientName = Console.ReadLine();
            Console.WriteLine("Enter The Client Reference");
            var clientRef = Console.ReadLine();
            using (var con = new ProjectContext())
            {
                var clientRole = con.EntityRoles.First(t => t.EntityRoleName == "Client");

                var client = con.Entities.Where(c => c.CompanyName == clientName).FirstOrDefault();
                if (client == null)
                {
                    client = new Entity { CompanyName = clientName };
                    con.Add<Entity>(client);
                }

                var newCase = new Case { CaseReference = caseRef };


                var caseclient = new CaseEntity();

                var caseClientDetails = new CaseEntityProperties();
                caseClientDetails.Reference = clientRef;

                caseclient.Case = newCase;
                caseclient.Entity = client;
                caseclient.CaseEntityProperties = caseClientDetails;
                caseclient.EntityRole = clientRole;

                con.CaseEntities.Add(caseclient);

                con.Add<Case>(newCase);
                con.SaveChanges();
            }
            Console.WriteLine($"Complete");
        }


    }
}
