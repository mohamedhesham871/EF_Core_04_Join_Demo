using EF_Core_04_Join_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel;

namespace EF_Core_04_Join_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CompanyDBContext companyDB = new CompanyDBContext())
            {

                //  CompanyDbContextSeed.Seed(companyDB);


                #region Demo [Notes]
                //Nav using two Request 
                //using nav[Explicit] just when you needed 

                //Eger Loading  

                //Lazy Loading 
                // install package 
                 //1- public  
                 //2- unSeald
                 //3- virtual

                #endregion



                #region Ex 01 using [Nav prop]
                //var Emp = (from e in companyDB.Empolyes
                //           where e.Id == 3
                //           select e).FirstOrDefault();

                //companyDB.Entry(Emp).Reference(nameof(Emp.Department)).Load();

                //if (Emp is not null)
                //    Console.WriteLine($"{Emp.Name} : {Emp.Department?.Name ?? "no Dept"}");

                #endregion
                Console.WriteLine("-----------------");
                #region ex 02 using [Nav Prop]
                //var Dept = (from d in companyDB.Departments
                //            where d.Id == 1
                //            select d).FirstOrDefault();
                //companyDB.Entry(Dept).Collection(nameof(Dept.empolyees)).Load();

                //if (Dept is not null)
                //{

                //    Console.WriteLine($"Dept ID :{Dept.Id} ,Dept Name :{Dept.Name} ");
                //    if (Dept.empolyees is not null)
                //    {
                //        foreach (var employee in Dept.empolyees)
                //        {
                //            Console.WriteLine($"******Emp Name : {employee.Name}");
                //        }
                //    }
                //}

                #endregion


                #region Ex 01 using Eger 
                //var Emp = (from e in companyDB.Empolyes.Include(nameof(Empolyee.Department))
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if (Emp is not null)
                //    Console.WriteLine($"{Emp.Name} : {Emp.Department?.Name ?? "no Dept"}");


                #endregion
                Console.WriteLine("-----------------");
                #region Ex 02 using Eger 
                //var Dept = (from d in companyDB.Departments.Include(nameof(Department.empolyees))
                //             where d.Id == 1
                //             select d).FirstOrDefault();
                // if (Dept is not null)
                // {

                //     Console.WriteLine($"Dept ID :{Dept.Id} ,Dept Name :{Dept.Name} ");
                //     if (Dept.empolyees is not null)
                //     {
                //         foreach (var employee in Dept.empolyees)
                //         {
                //             Console.WriteLine($"******Emp Name : {employee.Name}");
                //         }
                //     }
                // }
                #endregion

                #region Ex 01 using Lazy 
                //var Emp = (from e in companyDB.Empolyes
                //           where e.Id == 3
                //           select e).FirstOrDefault();


                //if (Emp is not null)
                //    Console.WriteLine($"{Emp.Name} : {Emp.Department?.Name ?? "no Dept"}");


                #endregion
                Console.WriteLine("-----------------");
                #region Ex 02 using Lazy 
                //var Dept = (from d in companyDB.Departments
                //            where d.Id == 1
                //            select d).FirstOrDefault();
                //if (Dept is not null)
                //{

                //    Console.WriteLine($"Dept ID :{Dept.Id} ,Dept Name :{Dept.Name} ");
                //    if (Dept.empolyees is not null)
                //    {
                //        foreach (var employee in Dept.empolyees)
                //        {
                //            Console.WriteLine($"******Emp Name : {employee.Name}");
                //        }
                //    }
                //}
                #endregion

                #region Join -GroupJoin()
                //using Query syntax
                var res = from d in companyDB.Departments
                          join e in companyDB.Empolyes
                          on d.Id equals e.DeparmentId
                          select new
                          {
                              employeeID = e.Id,
                              employeeNAme = e.Name,
                              DepartmentID = d.Id,
                              DeparmentName = d.Name

                          };
                //using Flent Syntax               Another table      Pk(Start)   Fk               select 
                res = companyDB.Departments.Join(companyDB.Empolyes, d => d.Id, e => e.DeparmentId,(d,e)=> new {
                    employeeID = e.Id,
                    employeeNAme = e.Name,
                    DepartmentID = d.Id,
                    DeparmentName = d.Name
                });
                //foreach (var item in res)
                //{
                //    Console.WriteLine(item);
                //}

                //--------------------------------------------------
                 //using flent syntax
                //                                                  table           Pk       FK
                var Groupres02 = companyDB.Departments.GroupJoin(companyDB.Empolyes,d=>d.Id,e=>e.DeparmentId,(department,Employee)=> new {department,Employee});

                var Groupres03 = from d in companyDB.Departments
                             join e in companyDB.Empolyes
                             on d.Id equals e.DeparmentId
                             into emp
                             select new
                             {
                                 department = d
                                ,
                                 Employee = emp
                             };


                foreach(var item in Groupres03)
                {
                    Console.WriteLine($"Department Name {item.department.Name}");
                    foreach(var emp in item.Employee)
                    {
                        Console.WriteLine($"------emp {emp.Name } , id {emp.Id}");
                    }
                }
                #endregion




            }
        }
    }
}
