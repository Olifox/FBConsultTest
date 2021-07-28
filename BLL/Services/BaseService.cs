using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public abstract class BaseService<T, E> : IBaseService<T> where T : BaseDTO where E : BaseEntity
    {
        protected readonly IBaseRepository<E> _repository;
        protected readonly IMapper _mapper;
        public BaseService(IBaseRepository<E> repository)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<E, T>();
                cfg.CreateMap<T, E>();
            });
            _mapper = config.CreateMapper();

            _repository = repository;
        }

        public void Add(T item)
        {
            if (item != null)
                _repository.Add(_mapper.Map<T, E>(item));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public T Find(int id)
        {
            return _mapper.Map<E, T>(_repository.Find(id));
        }

        public List<T> GetAll()
        {
            return _mapper
                .Map<IQueryable<E>, IQueryable<T>>(_repository.GetAll())
                .ToList();
        }

        public void Update(T item)
        {
            if (item != null)
                _repository.Update(_mapper.Map<T, E>(item));
        }
    }
}
