using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBaseService<T> where T : BaseDTO
    {
        List<T> GetAll();
        T Find(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
