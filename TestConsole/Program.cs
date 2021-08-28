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

                var caseHandlerRole = con.EntityRoles.First(t => t.EntityRoleName == "Case Handler");

                var clientRole = con.EntityRoles.First(t => t.EntityRoleName == "Client");
                var dataPointType = con.DataPointTypes.First(p => p.DataPointName == "Reference");

                var caseHandler = con.People.Where(p => p.Surname == "Boggs").FirstOrDefault();
                if (caseHandler == null)
                {
                    caseHandler = new IndividualEntity { Surname = "Boggs", FirstNames = "Ian" };
                    con.Add<Entity>(caseHandler);
                }

                var client = con.Companies.Where(c => c.CompanyName == clientName).FirstOrDefault();
                if (client == null)
                {
                    client = new CompanyEntity { CompanyName = clientName };
                    con.Add<Entity>(client);
                }

                var newCase = new Case { CaseReference = caseRef };


                var caseclient = new CaseEntity();

                var dataPoint = new CaseEntityDataPoint();
                dataPoint.DataPointType = dataPointType;
                dataPoint.DataPointValue = clientRef;


                caseclient.Case = newCase;
                caseclient.Entity = client;
                caseclient.CaseEntityDataPointList = new List<CaseEntityDataPoint>() { dataPoint };

                caseclient.EntityRole = clientRole;

                con.CaseEntities.Add(caseclient);

                var handlerCase = new CaseEntity();
                handlerCase.Case = newCase;
                handlerCase.Entity = caseHandler;
                handlerCase.EntityRole = caseHandlerRole;

                con.CaseEntities.Add(handlerCase);

                con.Add<Case>(newCase);
                con.SaveChanges();
            }
            Console.WriteLine($"Complete");
        }


    }
}
