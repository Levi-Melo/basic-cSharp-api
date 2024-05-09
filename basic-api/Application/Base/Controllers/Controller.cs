using basic_api.Data.Entities.Base;
using basic_api.Data.Repositories;
using basic_api.Domain.Base.Controller;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
namespace basic_api.Controllers
{
    public abstract class Controller<T, G, H> : ControllerBase, IController<T, G, H>
    where T : IBaseEntity
    where G : T
    where H : G

    {
        public Controller()
        {
            AddModelValidation();
        }
        public abstract T Get(G input);

        public abstract IEnumerable<T> Get(GetManyParams<G> input);

        public abstract T Insert(T entity);

        public abstract IEnumerable<T> Insert(IEnumerable<T> entity);

        public abstract T Update(H entity);

        public abstract IEnumerable<T> Update(IEnumerable<H> input);

        public abstract void Delete(G entity);

        public abstract void Delete(IEnumerable<G> input);

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
