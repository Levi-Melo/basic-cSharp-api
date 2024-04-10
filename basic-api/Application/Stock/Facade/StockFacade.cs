using basic_api.Application.Base;
using basic_api.Application.Stock.UseCases;
using basic_api.Domain.Stock.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Stock.Facade
{
    public class StockFacade(
        StockGetUseCase getUseCase, 
        StockDeleteUseCase deleteUseCase, 
        StockInsertUseCase insertUseCase, 
        StockUpdateUseCase updateUseCase
        ) : Facade<StockModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IStockFacade
    {
    }
}
