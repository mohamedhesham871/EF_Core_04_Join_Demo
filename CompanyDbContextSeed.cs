using EF_Core_04_Join_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EF_Core_04_Join_Demo
{
    internal static class CompanyDbContextSeed 
    {

        public static void Seed(CompanyDBContext DbContext )
        {
            if(!DbContext.Departments.Any())
            {
                // Should to Read  File 
                var DeparmentData = File.ReadAllText("D:\\C# project in Course\\EF_Core_04_Join_Demo\\DataSeed\\departments.json");
                //Deserialization is the process of converting the serialized format (JSON, XML, binary) back into an object.
                var departments = JsonSerializer.Deserialize<List<Department>>(DeparmentData);

                if (departments?.Count > 0)
                {
                    foreach (var department in departments)
                    {
                        DbContext.Departments.Add(department);
                    }
                    DbContext.SaveChanges();
                }
            }
            if (!DbContext.Empolyes.Any())
            {
                // Should to Read  File 
                var EmpolyeeData = File.ReadAllText("D:\\C# project in Course\\EF_Core_04_Join_Demo\\DataSeed\\employees.json");
                //Deserialization is the process of converting the serialized format (JSON, XML, binary) back into an object.
                var Empolyees = JsonSerializer.Deserialize<List<Empolyee>>(EmpolyeeData);

                if (Empolyees?.Count > 0)
                {
                    foreach (var emp in Empolyees)
                    {
                        DbContext.Empolyes.Add(emp);
                    }
                    DbContext.SaveChanges();
                }
            }
        }
    }

}
