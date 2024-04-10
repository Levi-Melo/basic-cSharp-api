using basic_api.Application.Base.UseCase;
using basic_api.Application.Book.UseCases;
using basic_api.Domain.Stock.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;
using basic_api.Infrastructure.Services;

namespace basic_api.Application.Stock.UseCases
{
    public class StockInsertUseCase(StockRepository repo, FileService fileService, BookGetUseCase getBook) : InsertUseCase<StockModel>(repo), IStockInsertUseCase
    {
        private readonly FileService _fileService = fileService;
        private readonly BookGetUseCase _getBook = getBook;

        public new async Task<StockModel> Execute(StockModel input)
        {
            var bookParam = new BookModel() 
            { 
                Id = input.Item.Id,
                Deleted = false
            };
            
            var item = _getBook.Execute(bookParam);
            
            if (input.File != null)
            {
                input.HaveFile = true;
                await _fileService.UploadAsync($"{input.Id}-{item.Title}", input.File);
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
