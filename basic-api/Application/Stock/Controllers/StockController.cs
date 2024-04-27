using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Stock.Controllers;
using basic_api.Domain.Stock.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Stock.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class StockController(IStockFacade facade) : Controller<StockModel>, IStockController
    {
        readonly IStockFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(StockModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<StockModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override StockModel Get(StockModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<StockModel> Get(GetManyParams<StockModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override StockModel Insert(StockModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<StockModel> Insert(IEnumerable<StockModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public override StockModel Update(StockModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<StockModel> Update(IEnumerable<StockModel> input)
        {
            return _facade.Update(input);
        }
    }
}
