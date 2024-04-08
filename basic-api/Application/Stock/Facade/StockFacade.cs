using basic_api.Application.Base;
using basic_api.Application.Base.UseCase;
using basic_api.Domain.Stock.Facade;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Stock.Facade
{
    public class StockFacade(
        GetUseCase<StockModel> getUseCase, 
        DeleteUseCase<StockModel> deleteUseCase, 
        InsertUseCase<StockModel> insertUseCase, 
        UpdateUseCase<StockModel> updateUseCase
        ) : Facade<StockModel>(
            getUseCase, 
            deleteUseCase, 
            insertUseCase, 
            updateUseCase), IStockFacade
    {
    }
}
