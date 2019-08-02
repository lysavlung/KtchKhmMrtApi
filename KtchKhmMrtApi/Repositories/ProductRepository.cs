using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KtchKhmMrtApi.Entities;
using Dapper;

namespace KtchKhmMrtApi.Repositories
{
    internal class ProductRepository : RepositoryBase, IProductRepository
    {
        public ProductRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public void Add(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entity.Id = Connection.ExecuteScalar<Guid>(
                    "INSERT INTO " + DbCommon.SCHEMA + ".Product(ProductCode,ProductName,ProductCategoryId) VALUES(@ProductCode,@ProductName,@ProductCategoryId);" +
                    "SELECT SCOPE_IDENTITY()",
                    param: new {ProductCode = entity.ProductCode, ProductName = entity.ProductName, ProductCategoryId = entity.ProductCategoryId},
                    transaction: Transaction
            );
        }

        public IEnumerable<Product> All()
        {
            return Connection.Query<Product>(
                "SELECT * FROM " + DbCommon.SCHEMA + ".Product"
            );
        }

        public Product Find(Guid id)
        {
            return Connection.Query<Product>(
                "SELECT * FROM " + DbCommon.SCHEMA + ".Product WHERE Id=@Id",
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public IEnumerable<Product> FindByProductCategoryId(Guid productCategoryId)
        {
            return Connection.Query<Product>(
                "SELECT * FROM " + DbCommon.SCHEMA + ".Product WHERE ProductCategoryId=@ProductCategoryId",
                param: new { ProductCategoryId = productCategoryId },
                transaction: Transaction
            );
        }

        public void Remove(Guid id)
        {
            Connection.Execute(
                "DELETE FROM " + DbCommon.SCHEMA + ".Product WHERE Id=@Id",
                param: new { Id = id },
                transaction: Transaction
            );
        }

        public void Remove(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Remove(entity.Id);
        }

        public void Update(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Connection.Execute(
                "UPDATE " + DbCommon.SCHEMA + ".Product SET ProductCode=@ProductCode, ProductName=@ProductName, ProductCategoryId=@ProductCategoryId WHERE Id=@Id",
                param: new { Id = entity.Id, ProductCode = entity.ProductCode, ProductName = entity.ProductName, ProductCategoryId = entity.ProductCategoryId },
                transaction: Transaction
            );
        }
    }
}
