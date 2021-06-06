using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.Repository
{
    public interface IEntityRepository<T>
    {
        T Get(long id);
        List<T> GetAll();
        void Create(T tObject);
        void Delete(long id);
        void Update(T tObject);
    }
}
