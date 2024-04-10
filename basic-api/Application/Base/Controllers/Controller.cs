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

        [HttpGet(Name = "")]
        public T Get(T input)
        {
            return _facade.Get(input);
        }

        [HttpGet(Name = "")]
        public IEnumerable<T> Get(IEnumerable<T> input)
        {
            return _facade.Get(input);
        }

        [HttpPost(Name = "")]
        public T Insert(T entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPost(Name = "")]
        public IEnumerable<T> Insert(IEnumerable<T> entity)
        {
            return _facade.Insert(entity);
        }

        [HttpPatch(Name = "")]
        public T Update(T entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch(Name = "")]
        public IEnumerable<T> Update(IEnumerable<T> input)
        {
            return _facade.Update(input);
        }

        [HttpDelete(Name = "")]
        public void Delete(T entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete(Name = "")]
        public void Delete(IEnumerable<T> input)
        {
            _facade.Delete(input);
        }
    }
}
