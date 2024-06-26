﻿using basic_api.Application.Base.UseCase;
using basic_api.Infrastructure.Database.Models;
using basic_api.Domain.Stock.UseCases;
using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Domain.Book.UseCases;

namespace basic_api.Application.Stock.UseCases
{
    public class StockGetUseCase(IStockRepository repo, IFileService fileService, IBookGetUseCase getBook) : GetUseCase<StockModel>(repo), IStockGetUseCase
    {
        private readonly IFileService _fileService = fileService;
        private readonly IBookGetUseCase _getBook = getBook;
        new public async Task<StockModel> Execute(StockModel input)
        {
            var bookParam = new BookModel() 
            { 
                Id = input.Item.Id,
                Deleted = false
            };

            var item = _getBook.Execute(bookParam);

            input.HaveFile = true;
            var file = await _fileService.DownloadAsync($"{input.Id}-{item.Title}");

            var result =  base.Execute(input);
            result.File = file;
            return result;
        }


        new public async Task<IEnumerable<StockModel>> Execute(GetManyParams<StockModel> input)
        {
            var items = base.Execute(input);
            var tasks = new List<Task<StockModel>>();
            foreach (var item in items)
            {
                tasks.Add(Execute(item));
            }
            var results = await Task.WhenAll(tasks);
            return results;
        }
    }
}
