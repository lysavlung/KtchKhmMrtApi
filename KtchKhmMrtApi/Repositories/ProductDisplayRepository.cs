using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KtchKhmMrtApi.Entities;

namespace KtchKhmMrtApi.Repositories
{
    public class ProductDisplayRepository : RepositoryBase, IProductDisplayRepository
    {
        public ProductDisplayRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public IEnumerable<ProductDisplay> findAllProductDisplay()
        {
            return Connection.Query<ProductDisplay>("SELECT A.Id,A.ProductCode,A.ProductName,B.CategoryName AS 'ProductCategory',C.ProductConfigValue" +
                                    " FROM " + DbCommon.SCHEMA + ".Product A LEFT JOIN " + DbCommon.SCHEMA + ".Category B ON B.Id = A.ProductCategoryId"+
                                    " LEFT JOIN " + DbCommon.SCHEMA + ".ProductConfig C ON C.ProductId = A.Id", 
                                    null,
                                    transaction: Transaction);
        }

        public ProductDisplay findProductDisplayByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException();

            return Connection.QueryFirstOrDefault<ProductDisplay>("SELECT A.Id,A.ProductCode,A.ProductName,B.CategoryName AS 'ProductCategory',C.ProductConfigValue" +
                                                    " FROM " + DbCommon.SCHEMA + "P.roduct A LEFT JOIN " + DbCommon.SCHEMA + ".Category B ON B.Id = A.ProductCategoryId" +
                                                    " LEFT JOIN " + DbCommon.SCHEMA + ".ProductConfig C ON C.ProductId = A.Id" +
                                                    " WHERE A.ProductCode=@Code",
                                                    param: new { Code = code },
                                                    transaction: Transaction);
        }
    }
}
