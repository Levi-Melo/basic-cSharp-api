using basic_api.Data.Entities.Base;
using basic_api.Domain.Base.Controller;
using basic_api.Domain.Base.Facade;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Controllers
{
    public abstract class Controller<T>(IFacade<T> facade) : ControllerBase, IController<T>
    where T : IBaseEntity
    {
        private readonly IFacade<T> _facade = facade;

        [HttpGet, Route("[controller]")]
        public T Get(T input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public IEnumerable<T> Get(IEnumerable<T> input)
        {
            return _facade.Get(input);
        }

        [HttpPost, Route("[controller]")]
        public T Insert(T entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost, Route("[controller]/many")]
        public IEnumerable<T> Insert(IEnumerable<T> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch, Route("[controller]")]
        public T Update(T entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch, Route("[controller]/many")]
        public IEnumerable<T> Update(IEnumerable<T> input)
        {
            return _facade.Update(input);
        }

        [HttpDelete, Route("[controller]")]
        public void Delete(T entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete, Route("[controller]/many")]
        public void Delete(IEnumerable<T> input)
        {
            _facade.Delete(input);
        }
    }
}
