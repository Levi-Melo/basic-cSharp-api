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
                // Ignora m�todos especiais (como construtores)
                if (method.IsSpecialName)
                    continue;

                // Obt�m o delegate da fun��o original
                Action originalMethod = (Action)Delegate.CreateDelegate(typeof(Action), this, method);

                // Substitui a fun��o original por uma nova fun��o que chama o bloco de c�digo primeiro
                Action newMethod = () =>
                {
                    if (!ModelState.IsValid)
                    {
                        throw new Exception();
                    }
                    originalMethod(); // Chama a fun��o original
                };

                // Atualiza o m�todo para a nova fun��o
                Delegate.Combine(originalMethod, newMethod);
            }
        }
    }
}
