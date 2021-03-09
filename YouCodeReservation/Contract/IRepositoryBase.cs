using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouCodeReservation.Contract
{
   public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        bool IsExist(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();

    }
}
