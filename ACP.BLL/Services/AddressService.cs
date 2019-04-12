using ACP.BLL.Models;
using ACP.DAL.DbLayer;
using ACP.Repository;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACP.BLL.Services
{
    public class AddressService : GenericService<Address, AddressDTO>
    {
        public AddressService(IGenericRepository<Address> rep) : base(rep) { }
        

        protected virtual IMapper InitMapper()
        {
            return new MapperConfiguration(cfg =>
             {
                 cfg.AddExpressionMapping();
                 cfg.CreateMap<Address, AddressDTO>()
                  .ForMember("SubDivisionName", opt => opt.MapFrom(a => a.Subdivision.SubdivisionName))
                  .ForMember("StreetName", opt => opt.MapFrom(a => a.Street.StreetName))
                  ;
                 cfg.CreateMap<AddressDTO, Address>();

             }).CreateMapper();
        }
    }
}
