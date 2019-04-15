using ACP.DAL.Repository;
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



        /// <summary>
        /// Gets every element of repository typed by TemplateDTO
        /// </summary>
        /// <returns> IEnumerable object </returns>
        public IEnumerable<TDTO> GetAll() => repository.GetAll().Select(a => _mapper.Map<TDTO>(a));

        /// <summary>
        /// Returns every element of typed repository which passes to chosen predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns> IEnumerable object</returns>
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

        /// <summary>
        /// Gets an element by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> TemplateDTO object </returns>
        public TDTO Get(int id)
        {
            T address = repository.Get(id);
            return _mapper.Map<TDTO>(address);
        }

        /// <summary>
        /// Adds new element to repository typed TemplateDTO.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>A copy of updated object</returns>
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

        /// <summary>
        /// Updates an element which has same id as TDTO obj.id with data of obj
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>A copy of opdated object</returns>
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

        /// <summary>
        /// Deletes an object by object copy
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>A copy of deleted object</returns>
        public TDTO Delete(TDTO obj)
        {
            T address = _mapper.Map<T>(obj);
            repository.Delete(address);
            repository.Save();
            return _mapper.Map<TDTO>(address);
        }

        /// <summary>
        /// Deletes an object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A copy of deleted object</returns>
        public TDTO Delete(int id)
        {
            T address = repository.Get(id);
            repository.Delete(address);
            repository.Save();
            return _mapper.Map<TDTO>(address);
        }
    }
}
