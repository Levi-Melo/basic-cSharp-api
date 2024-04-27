using basic_api.Controllers;
using basic_api.Data.Repositories;
using basic_api.Domain.Genre.Controllers;
using basic_api.Domain.Genre.Facade;
using basic_api.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Application.Genre.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController(IGenreFacade facade) : Controller<GenreModel>(), IGenreController
    {
        readonly IGenreFacade _facade = facade;

        [HttpDelete, Route("[controller]")]
        public override void Delete(GenreModel entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public override void Delete(IEnumerable<GenreModel> input)
        {
            _facade.Delete(input);
        }

        [HttpGet, Route("[controller]")]
        public override GenreModel Get(GenreModel input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public override IEnumerable<GenreModel> Get(GetManyParams<GenreModel> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public override GenreModel Insert(GenreModel entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public override IEnumerable<GenreModel> Insert(IEnumerable<GenreModel> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public override GenreModel Update(GenreModel entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public override IEnumerable<GenreModel> Update(IEnumerable<GenreModel> input)
        {
            return _facade.Update(input);
        }
    }
}
