using basic_api.Controllers;
using basic_api.Domain.Stock.Controllers;
using basic_api.Domain.Stock.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Stock.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class StockController(IStockFacade facade) : Controller<StockModel>(facade), IStockController
    {
    }
}
