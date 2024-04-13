using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Stock.UseCases
{
    public class StockUpdateUseCase(IStockRepository repo, IFileService fileService) : UpdateUseCase<StockModel>(repo), IStockUpdateUseCase
    {
        private readonly IFileService _fileService = fileService;
        public new async Task<StockModel> Execute(StockModel input)
        {
            if (input.File != null)
            {
                input.HaveFile = true;
                await _fileService.UploadAsync($"{input.Id}", input.File);
            }

            return base.Execute(input);
        }

        public new async Task<IEnumerable<StockModel>> Execute(IEnumerable<StockModel> input)
        {
            repo.BeginTransaction();
            var tasks = new List<Task<StockModel>>();
            foreach (var item in input)
            {
                tasks.Add(Execute(item));
            }
            var results = await Task.WhenAll(tasks);
            repo.Commit();
            return results;
        }
    }
}
