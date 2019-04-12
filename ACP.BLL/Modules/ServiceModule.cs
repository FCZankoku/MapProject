using ACP.BLL.Models;
using ACP.BLL.Services;
using ACP.DAL.DbLayer;
using ACP.DAL.Repositories;
using ACP.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
