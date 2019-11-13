using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KtchKhmMrtApi.Entities;
using Dapper;
using KtchKhmMrtDataApi.Repositories;

namespace KtchKhmMrtApi.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        protected override void ExecuteAdd(Product entity)
        {
            entity.Id = Connection.ExecuteScalar<Guid>(
                    "INSERT INTO " + DbCommon.SCHEMA + ".Product(ProductCode,ProductName,ProductCategoryId) VALUES(@ProductCode,@ProductName,@ProductCategoryId);" +
                    "SELECT SCOPE_IDENTITY()",
                    param: new { ProductCode = entity.ProductCode, ProductName = entity.ProductName, ProductCategoryId = entity.ProductCategoryId },
                    transaction: Transaction
            );
        }

        protected override void ExecuteUpdate(Product entity)
        {
            Connection.Execute(
                "UPDATE " + DbCommon.SCHEMA + ".Product SET ProductCode=@ProductCode, ProductName=@ProductName, ProductCategoryId=@ProductCategoryId WHERE Id=@Id",
                param: new { Id = entity.Id, ProductCode = entity.ProductCode, ProductName = entity.ProductName, ProductCategoryId = entity.ProductCategoryId },
                transaction: Transaction
            );
        }
    }
}
