using ACP.BLL.Models;
using ACP.DAL.DbLayer;
using ACP.DAL.Repository;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ACP.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACP.BLL.Services
{
    public class SubdivisionService : GenericService<Subdivision, SubdivisionDTO>
    {
        public SubdivisionService(IGenericRepository<Subdivision> sdRep): base(sdRep)
        {

        }
    }
}
