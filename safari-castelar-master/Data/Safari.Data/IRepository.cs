using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {                
        TEntity Create(TEntity entity);
        List<TEntity> Read();
        TEntity ReadBy(int id);
        void Update(TEntity entity);
        void Delete(int id);        
    }
}
