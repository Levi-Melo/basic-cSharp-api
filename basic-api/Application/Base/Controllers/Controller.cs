using basic_api.Domain.Base.Controller;
using basic_api.Domain.Base.Facade;
using basic_api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace basic_api.Controllers
{
    public abstract class Controller<T,G>(IFacade<T,G> facade) : ControllerBase, IController<T,G>
    where T : IBaseEntity
    where G : T
    {
        private IFacade<T,G> _facade = facade;

        [HttpGet(Name = "")]
        public T Get(G input)
        {
            return _facade.Get(input);
        }

        [HttpGet(Name = "")]
        public IEnumerable<T> Get(IEnumerable<G> input)
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
        public T Update(G entity)
        {
            return _facade.Update(entity);
        }

        [HttpPatch(Name = "")]
        public IEnumerable<T> Update(IEnumerable<G> input)
        {
            return _facade.Update(input);
        }

        [HttpDelete(Name = "")]
        public void Delete(G entity)
        {
            _facade.Delete(entity);
        }

        [HttpDelete(Name = "")]
        public void Delete(IEnumerable<G> input)
        {
            _facade.Delete(input);
        }
    }
}
