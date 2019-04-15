using ACP.BLL.Models;
using ACP.BLL.Services;
using ACP.DAL.DbLayer;
using ACP.DAL.Repositories;
using ACP.DAL.Repository;
using Ninject.Modules;
using System.Data.Entity;

namespace ACP.BLL.Modules
{
    public class ServiceModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IGenericService<AddressDTO>>().To<AddressService>();
            Bind<IGenericService<StreetDTO>>().To<StreetService>();
            Bind<IGenericService<SubdivisionDTO>>().To<SubdivisionService>();


            Bind<IGenericRepository<Address>>().To<AddressRepository>();
            Bind<IGenericRepository<Street>>().To<StreetRepository>();
            Bind<IGenericRepository<Subdivision>>().To<SubdivisionRepository>();

            Bind<DbContext>().To<MapContext>().InTransientScope();
        }

        
    }
}
