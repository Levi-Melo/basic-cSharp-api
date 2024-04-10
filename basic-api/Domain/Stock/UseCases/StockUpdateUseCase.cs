using basic_api.Domain.Base.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Domain.Stock.UseCases
{
    public interface IStockUpdateUseCase : IUpdateUseCase<StockModel>
    {
        new Task<StockModel> Execute(StockModel input);

        new Task<IEnumerable<StockModel>> Execute(IEnumerable<StockModel> input);
    }
}
