using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KtchKhmMrtDataApi.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IEnumerable<T> All(string tableName);
        T Find(string tableName, Guid id);
        void Remove(string tableName, Guid id);
        void Remove(T entity);
        void Update(T entity);
    }
}
