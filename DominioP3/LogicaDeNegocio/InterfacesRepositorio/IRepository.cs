using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Add(T value);
        void Update(T value);
        void Remove(int id);


    }
}
