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

                var caseHandler = con.Users.FirstOrDefault(u => u.FullName == "Ian Boggs");

                var initialStatus = con.CaseStatusList.FirstOrDefault(cs => cs.CaseStatusName == "In Progress");

                var client = con.Clients.FirstOrDefault(c => c.ClientName == clientName);
                if (client == null)
                {
                    client = new ClientEntity { ClientName = clientName };
                    con.Add<ClientEntity>(client);
                }

                var newCase = new Case { CaseReference = caseRef };

                newCase.CaseHandler = caseHandler;
                newCase.Client = client;
                newCase.ClientReference = clientRef;
                newCase.CurrentStatus = initialStatus;

                con.Add<Case>(newCase);
                con.SaveChanges();
            }
            Console.WriteLine($"Complete");
        }


    }
}
