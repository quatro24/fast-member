using FastMember;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetItems();
            var connectionString = "data source=localhost;initial catalog=test;Connect Timeout=60;Integrated Security=true";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (var bcp = new SqlBulkCopy(sqlConnection))
                using (var reader = ObjectReader.Create(data))
                {
                    bcp.DestinationTableName = "misc";
                    bcp.AddMappings(data);
                    bcp.WriteToServer(reader);
                }
            }

            Console.WriteLine("Hello World!");
        }

        static IEnumerable<Misc> GetItems()
        {
            return new List<Misc>
            {
                new Misc { HitId = DateTime.Now.Millisecond, ApplicationId = DateTime.Now.Millisecond.ToString() },
                new Misc { HitId = DateTime.Now.Millisecond, ApplicationId = DateTime.Now.Millisecond.ToString() },
                new Misc { HitId = DateTime.Now.Millisecond, ApplicationId = DateTime.Now.Millisecond.ToString() },
                new Misc { HitId = DateTime.Now.Millisecond, ApplicationId = DateTime.Now.Millisecond.ToString() }
            };
        }
    }
}
