using basic_api.Application.Base;
using basic_api.Domain.Stock.UseCases;
using basic_api.Domain.Stock.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Stock.Facade
{
    public class StockFacade(
        IStockGetUseCase getUseCase, 
        IStockDeleteUseCase deleteUseCase, 
        IStockInsertUseCase insertUseCase, 
        IStockUpdateUseCase updateUseCase
        ) : Facade<StockModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IStockFacade
    {
    }
}
