using basic_api.Application.Base.UseCase;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;
using basic_api.Infrastructure.Database.Repositories;

namespace basic_api.Application.Order.UseCases
{
    public class OrderDeleteUseCase(OrderRepository repo) : DeleteUseCase<OrderModel>(repo), IOrderDeleteUseCase
    {
        private readonly OrderRepository _repo = repo;
        public new void Execute(OrderModel entity)
        {
            var found = _repo.Get(entity);

            if(found.DevolveAt != null && found.Devolved != null)
            {
                throw new Exception();
            }

            base.Execute(entity);
        }

        public new void Execute(IEnumerable<OrderModel> input)
        {
            foreach(var entity in input)
            {
                Execute(entity);
            }
        }
    }
}
