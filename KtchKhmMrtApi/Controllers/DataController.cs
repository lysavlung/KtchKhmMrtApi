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
        IUnitOfWork _uow;

        public DataController(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        // Retrieve a list of ProductDisplay
        // GET: api/data/
        [HttpGet]
        public ActionResult<IEnumerable<ProductDisplay>> GetListProductDisplay()
        {
            var list = new List<ProductDisplay>();

            list = (List<ProductDisplay>)_uow.ProductDisplayRepository.findAllProductDisplay();

            return list;
        }


        // Retrieve a single ProductDisplay by ProductCode
        // GET: api/data/{code}
        [HttpGet("{code}")]
        public ActionResult<ProductDisplay> GetProductDisplayByCode(string code)
        {
            var productDisplay = default(ProductDisplay);

            productDisplay = _uow.ProductDisplayRepository.findProductDisplayByCode(code);

            return productDisplay;
        }

        // Add new Product
        // api/data
        [HttpPost]
        public ActionResult<int> PostProduct(Product item)
        {
            int affectedRow = 0;

            _uow.ProductRepository.Add(item);
            _uow.Commit();

            affectedRow = 1;

            return affectedRow;
        }

        // Update existing Product
        // api/data
        [HttpPut]
        public ActionResult<int> PutProduct(Product item)
        {
            int affectedRow = 0;

            _uow.ProductRepository.Update(item);
            _uow.Commit();

            affectedRow = 1;

            return affectedRow;
        }
    }
}
