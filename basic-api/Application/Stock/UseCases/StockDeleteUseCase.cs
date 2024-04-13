using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Stock.UseCases
{
    public class StockDeleteUseCase(IStockRepository repo) : DeleteUseCase<StockModel>(repo), IStockDeleteUseCase
    {
    }
}
