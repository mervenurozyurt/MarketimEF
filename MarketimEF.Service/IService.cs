using MarketimEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Service
{
    public interface IService<T> where T : IEntity
    {
        List<T> List();
        int Save(T obj);
        int Update(T obj);
        bool Delete(int id);
        T Get(int id);
    }
}
