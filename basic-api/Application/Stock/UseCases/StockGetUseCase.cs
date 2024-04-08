using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Stock.UseCases;

namespace basic_api.Application.Stock.UseCases
{
    public class StockGetUseCase(BaseRepository<StockModel> repo) : GetUseCase<StockModel>(repo), IStockGetUseCase
    {
    }
}
