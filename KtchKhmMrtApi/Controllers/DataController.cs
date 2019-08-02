using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KtchKhmMrtApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KtchKhmMrtApi.DapperUnitOfWork;
using KtchKhmMrtApi.Repositories;

namespace KtchKhmMrtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        // Retrieve a list of ProductDisplay
        // GET: api/data/
        [HttpGet]
        public IEnumerable<ProductDisplay> GetListProductDisplay()
        {
            var list = new List<ProductDisplay>();

            using(var uow = new UnitOfWork(DbCommon.SQL_CONNECTION_STRING))
            {
                list = (List<ProductDisplay>)uow.ProductDisplayRepository.findAllProductDisplay();
            }

            return list;
        }


        // Retrieve a single ProductDisplay by ProductCode
        // GET: api/data/{code}
        [HttpGet("{code}")]
        public ActionResult<ProductDisplay> GetProductDisplayByCode(string code)
        {
            var productDisplay = default(ProductDisplay);

            using(var uow = new UnitOfWork(DbCommon.SQL_CONNECTION_STRING))
            {
                productDisplay = uow.ProductDisplayRepository.findProductDisplayByCode(code);
            }

            return productDisplay;
        }

        // Add new Product
        // api/data
        [HttpPost]
        public ActionResult<int> PostProduct(Product item)
        {
            int affectedRow = 0;

            using(var uow = new UnitOfWork(DbCommon.SQL_CONNECTION_STRING))
            {
                uow.ProductRepository.Add(item);
                uow.Commit();

                affectedRow = 1;
            }

            return affectedRow;
        }

        // Update existing Product
        // api/data
        [HttpPut]
        public ActionResult<int> PutProduct(Product item)
        {
            int affectedRow = 0;

            using (var uow = new UnitOfWork(DbCommon.SQL_CONNECTION_STRING))
            {
                uow.ProductRepository.Update(item);
                uow.Commit();

                affectedRow = 1;
            }

            return affectedRow;
        }
    }
}
