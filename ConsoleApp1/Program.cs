using ACP.BLL.Models;
using ACP.BLL.Modules;
using ACP.BLL.Services;
using ACP.DAL.DbLayer;
using ACP.DAL.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var kernel = new StandardKernel(new ServiceModule());

                StreetService streetService = kernel.Get<StreetService>();
                AddressService addressService = kernel.Get<AddressService>();
                SubdivisionService subdivService = kernel.Get<SubdivisionService>();

                Console.WriteLine("Get All");
                StreetDTO s = streetService.GetAll().ToList()[0];
                AddressDTO a = addressService.GetAll().ToList()[0];
                SubdivisionDTO sd = subdivService.GetAll().ToList()[0];

                Console.WriteLine("Works");
                Console.WriteLine($"{s.StreetId}  {s.StreetName}");
                Console.WriteLine($"{a.House} {a.Latitude} {a.Longitude} {a.Serial} {a.StreetId} {a.SubdivisionId} {a.СountEntrance} {a.СountFloor}");
                Console.WriteLine($"{sd.SubdivisionId} {sd.SubdivisionName}");

                Console.WriteLine("");
                Console.WriteLine("Get");
                Console.WriteLine("Works");

                s = streetService.Get(1);
                a = addressService.Get(1);
                sd = subdivService.Get(1);

                Console.WriteLine($"{s.StreetId}  {s.StreetName}");
                Console.WriteLine($"{a.House} {a.Latitude} {a.Longitude} {a.Serial} {a.StreetId} {a.SubdivisionId} {a.СountEntrance} {a.СountFloor}");
                Console.WriteLine($"{sd.SubdivisionId} {sd.SubdivisionName}");

                Console.WriteLine("");
                Console.WriteLine("Add");
                Console.WriteLine("Works");

                s = new StreetDTO() { StreetName = "Тестовая Улица 1" };
                a = new AddressDTO() { House = "TestAddress1", Latitude = decimal.Zero, Longitude = decimal.Zero, Serial = "Test Serial1", StreetId = streetService.GetAll().Last().StreetId, SubdivisionId = subdivService.GetAll().Last().SubdivisionId, СountEntrance = 0, СountFloor = 0 };
                sd = new SubdivisionDTO() { SubdivisionName = "SubDiv Test1" };

                Console.WriteLine(streetService.Add(s));
                Console.WriteLine(addressService.Add(a).House);
                Console.WriteLine(a.House);
                Console.Write(addressService.GetAll().Where(g => g.House == a.House).FirstOrDefault().AddressId);
                Console.WriteLine(subdivService.Add(sd));


                Console.WriteLine("");
                Console.WriteLine("Update");
                Console.WriteLine("Works");


                streetService.Update(new StreetDTO() { StreetId = streetService.GetAll().Last().StreetId, StreetName = "Updated Street" });
                Console.WriteLine($"{addressService.GetAll().First().AddressId} {addressService.GetAll().First().StreetId} {addressService.GetAll().First().House}");
                addressService.Update(new AddressDTO() { AddressId = addressService.GetAll().First().AddressId, StreetId = addressService.GetAll().First().StreetId, SubdivisionId = addressService.GetAll().First().SubdivisionId, House = "Updated" });
                subdivService.Update(new SubdivisionDTO() { SubdivisionId = subdivService.GetAll().Last().SubdivisionId, SubdivisionName = "Updated SubDiv" });

                Console.WriteLine(streetService.GetAll().Last().StreetName);
                Console.WriteLine(addressService.GetAll().Last().House);
                Console.WriteLine(subdivService.GetAll().Last().SubdivisionName);


                Console.WriteLine("");
                Console.WriteLine("Delete");

                //Console.WriteLine(streetService.Delete(streetService.GetAll().Last().StreetId).StreetName);
                //Console.WriteLine(addressService.Delete(1459).House);
                //Console.WriteLine(subdivService.Delete(subdivService.GetAll().Last().SubdivisionId).SubdivisionName);



                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
