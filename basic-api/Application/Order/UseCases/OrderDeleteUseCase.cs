using basic_api.Application.Base.UseCase;
using basic_api.Data.Repositories;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Order.UseCases
{
    public class OrderDeleteUseCase(IOrderRepository repo) : DeleteUseCase<OrderModel>(repo), IOrderDeleteUseCase
    {
        private readonly IOrderRepository _repo = repo;
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
            _repo.BeginTransaction();
            foreach (var entity in input)
            {
                Execute(entity);
            }
            _repo.Commit();
        }
    }
}
