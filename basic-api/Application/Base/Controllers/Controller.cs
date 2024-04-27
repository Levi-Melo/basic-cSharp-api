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
