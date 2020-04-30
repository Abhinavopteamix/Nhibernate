using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

using System;
using System.Linq;
using System.Reflection;

namespace Nhibernate1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();

            //string DataSource = "qa-opteamizer.opteamix.com";
            //string InitialCatalog = "BookListRazor";
            //string IntegratedSecurity = True;
            //string ConnectTimeout = 15;
            //string Encrypt = False;
            //string TrustServerCertificate = False;
            //string ApplicationIntent = ReadWrite;
            //string MultiSubnetFailover = File;

            cfg.DataBaseIntegration(x => { x.ConnectionString = "server=qa-opteamizer.opteamix.com;initial catalog=BookListRazor;user=OpteamixCICP;password=CICP2#4%;";
            x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            var sefact = cfg.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {

                using (var tx = session.BeginTransaction())
                {
                    //perform database logic 
                    //#region CREATE

                    var emp1 = new Employee
                    {
                        
                        FirstName = "Allan",
                        Position = "1",
                        DepartmentId = 5

                    };

                    //var emp2 = new Employee
                    //{
                    //    Id = 6,
                    //    FirstName = "Jerry",
                    //    Position = "1",
                    //    DepartmentId = 1
                    //};

                    session.Save(emp1);
                    //session.Save(emp2);


                    //#endregion

                    //#region READ

                    //var employees = session.CreateCriteria<Employee>().List<Employee>();

                    //foreach (var employee in employees)
                    //{
                    //    Console.WriteLine("{0} \t{1} \t{2} \t{3}",
                    //       employee.Id, employee.FirstName, employee.Position, employee.DepartmentId);
                    //}

                    //#endregion

                    tx.Commit();
                }

                Console.ReadLine();
            }
        }
    }
}
