using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Stock.UseCases
{
    public interface IStockGetUseCase : IGetUseCase<StockModel>
    {
    }
}
