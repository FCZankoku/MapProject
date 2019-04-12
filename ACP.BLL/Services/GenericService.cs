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
    public abstract class GenericService<T, TDTO> : IGenericService<TDTO> where T : class, new() where TDTO : class, new()
    {
        protected IGenericRepository<T> repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<T> rep)
        {
            repository = rep;
            _mapper = InitMapper();
        }



        protected virtual IMapper InitMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<T, TDTO>();
                cfg.CreateMap<TDTO, T>();

            }).CreateMapper();
        }


        public IEnumerable<TDTO> GetAll() => repository.GetAll().Select(a => _mapper.Map<TDTO>(a));

        public IEnumerable<TDTO> FindBy(Expression<Func<TDTO, bool>> predicate)
        {
            try
            {
                var predicateAddress = _mapper.Map<Expression<Func<T, bool>>>(predicate);
                return repository.FindBy(predicateAddress)
                    .Select(c => _mapper.Map<TDTO>(c));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TDTO Get(int id)
        {
            T address = repository.Get(id);
            return _mapper.Map<TDTO>(address);
        }

        public TDTO Add(TDTO obj)
        {
            try
            {
                T address = _mapper.Map<T>(obj);
                repository.AddOrUpdate(address);
                repository.Save();
                return _mapper.Map<TDTO>(address);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public TDTO Update(TDTO obj)
        {
            try
            {
                T address = _mapper.Map<T>(obj);
                repository.AddOrUpdate(address);
                repository.Save();
                return _mapper.Map<TDTO>(address);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public TDTO Delete(TDTO obj)
        {
            T address = _mapper.Map<T>(obj);
            repository.Delete(address);
            repository.Save();
            return _mapper.Map<TDTO>(address);
        }

        public TDTO Delete(int id)
        {
            T address = repository.Get(id);
            repository.Delete(address);
            repository.Save();
            return _mapper.Map<TDTO>(address);
        }
    }
}
