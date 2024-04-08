using basic_api.Application.Base.UseCase;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Stock.UseCases
{
    public class StockUpdateUseCase(BaseRepository<StockModel> repo) : UpdateUseCase<StockModel>(repo), IStockUpdateUseCase
    {
    }
}
