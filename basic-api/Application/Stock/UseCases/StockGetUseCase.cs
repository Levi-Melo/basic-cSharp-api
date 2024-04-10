using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Stock.UseCases;
using basic_api.Application.Book.UseCases;
using basic_api.Infrastructure.Services;

namespace basic_api.Application.Stock.UseCases
{
    public class StockGetUseCase(StockRepository repo, FileService fileService, BookGetUseCase getBook) : GetUseCase<StockModel>(repo), IStockGetUseCase
    {
        private readonly FileService _fileService = fileService;
        private readonly BookGetUseCase _getBook = getBook;
        new public async Task<StockModel> Execute(StockModel input)
        {
            var bookParam = new BookModel() 
            { 
                Id = input.Item.Id,
                Deleted = false
            };

            var item = _getBook.Execute(bookParam);

            input.HaveFile = true;
            await _fileService.DownloadAsync($"{input.Id}-{item.Title}");

            return base.Execute(input);
        }


        new public async Task<IEnumerable<StockModel>> Execute(IEnumerable<StockModel> input)
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
