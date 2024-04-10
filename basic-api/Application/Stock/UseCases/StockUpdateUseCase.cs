using basic_api.Application.Base.UseCase;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Service;

namespace basic_api.Application.Stock.UseCases
{
    public class StockUpdateUseCase(StockRepository repo, FileService fileService) : UpdateUseCase<StockModel>(repo), IStockUpdateUseCase
    {
        private readonly FileService _fileService = fileService;
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
            var tasks = new List<Task<StockModel>>();
            foreach (var item in input)
            {
                tasks.Add(Execute(item));
            }
            var results = await Task.WhenAll(tasks);
            return results;
        }
    }
}
