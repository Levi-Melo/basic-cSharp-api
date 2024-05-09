using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Book.Controllers;
using basic_api.Domain.Book.Facade;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Models.DTO.Get;
using basic_api.Infrastructure.Database.Models.DTO.Update;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Book.Controllers
{
    [ApiController]
    [Route("books")]
    public class BookController(IBookFacade facade) : Controller<BookModel, BookGetModel, BookUpdateModel>(), IBookController
    {
        readonly IBookFacade _facade = facade;
        
        [HttpDelete, Route("[controller]")]
        public override void Delete(BookGetModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<BookGetModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override BookModel Get(BookGetModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<BookModel> Get(GetManyParams<BookGetModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override BookModel Insert(BookModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<BookModel> Insert(IEnumerable<BookModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public override BookModel Update(BookUpdateModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<BookModel> Update(IEnumerable<BookUpdateModel> input)
        {
            return _facade.Update(input);
        }
    }
}
