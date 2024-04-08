﻿using basic_api.Domain.Base.Controller;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Stock.Controllers
{
    public interface IStockController : IController<StockModel>
    {
    }
}