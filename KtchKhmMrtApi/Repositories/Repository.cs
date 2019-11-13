using Dapper;
using KtchKhmMrtApi.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KtchKhmMrtDataApi.Repositories
{
    public class Repository<T> : RepositoryBase, IRepository<T>
    {
        public Repository(IDbTransaction transaction) : base(transaction)
        {
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            ExecuteAdd(entity);
        }

        protected virtual void ExecuteAdd(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> All(string tableName)
        {
            return Connection.Query<T>(
                "SELECT * FROM " + DbCommon.SCHEMA + "." + tableName
            );
        }

        public T Find(string tableName, Guid id)
        {
            return Connection.Query<T>(
                "SELECT * FROM " + DbCommon.SCHEMA + "." + tableName + " WHERE Id=@Id",
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public void Remove(string tableName, Guid id)
        {
            Connection.Execute(
                "DELETE FROM " + DbCommon.SCHEMA + "." + tableName + " WHERE Id=@Id",
                param: new { Id = id },
                transaction: Transaction
            );
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            ExecuteUpdate(entity);
        }

        protected virtual void ExecuteUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
