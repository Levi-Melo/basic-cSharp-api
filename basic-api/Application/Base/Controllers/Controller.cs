using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;
using basic_api.Domain.Base.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
namespace basic_api.Controllers
{
    public abstract class Controller<T> : ControllerBase, IController<T>
    where T : IBaseEntity
    {
        public Controller()
        {
            AddModelValidation();
        }
        public abstract T Get(T input);

        public abstract IEnumerable<T> Get(GetManyParams<T> input);

        public abstract T Insert(T entity);

        public abstract IEnumerable<T> Insert(IEnumerable<T> entity);

        public abstract T Update(T entity);

        public abstract IEnumerable<T> Update(IEnumerable<T> input);

        public abstract void Delete(T entity);

        public abstract void Delete(IEnumerable<T> input);

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
