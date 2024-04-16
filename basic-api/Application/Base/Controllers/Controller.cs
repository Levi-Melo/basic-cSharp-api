using basic_api.Application.Base;
using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;
using basic_api.Domain.Base.Controller;
using basic_api.Domain.Base.Facade;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Reflection.Emit;
namespace basic_api.Controllers
{
    public abstract class Controller<T> : ControllerBase, IController<T>
    where T : IBaseEntity
    {
        private readonly IFacade<T> _facade;
     
        public Controller(IFacade<T> facade)
        {
            _facade = facade;
            AddModelValidation();
        }

    [HttpGet, Route("[controller]")]
        public T Get(T input)
        {
            return _facade.Get(input);
        }

        [HttpGet, Route("[controller]/many")]
        public IEnumerable<T> Get(GetManyParams<T> input)
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

        private void AddModelValidation()
        {
            MethodInfo[] methods = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                // Ignora métodos especiais (como construtores)
                if (method.IsSpecialName)
                    continue;

                // Obtém o delegate da função original
                Action originalMethod = (Action)Delegate.CreateDelegate(typeof(Action), this, method);

                // Substitui a função original por uma nova função que chama o bloco de código primeiro
                Action newMethod = () =>
                {
                    if (!ModelState.IsValid)
                    {
                        throw new Exception();
                    }
                    originalMethod(); // Chama a função original
                };

                // Atualiza o método para a nova função
                Delegate.Combine(originalMethod, newMethod);
            }
        }
    }
}
