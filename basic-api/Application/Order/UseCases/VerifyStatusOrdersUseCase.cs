using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Domain.Order.UseCases;
using basic_api.Infrastructure.Database.Models;

namespace basic_api.Application.Order.UseCases
{
    public class VerifyStatusOrderUseCase(IOrderRepository repo, IEmailService emailService): IVerifyStatusOrderUsecase
    {
        private readonly IOrderRepository _repo = repo;
        private readonly IEmailService _emailService = emailService;
        public async Task Execute()
        {
            GetManyParams<OrderModel> param = new()
            {
            };
            var orders = _repo.Get(param);

            foreach (var order in orders)
            {
                if (order.DevolveAt != null && order.Devolved == null)
                {
                    var isBefore = ((DateTime)order.DevolveAt - DateTime.Now).TotalDays;
                    if (isBefore < 0)
                    {
                        await _emailService.Send(order.OrderAuthor.Email, "Pedido está em atraso", $"");
                        order.Devolved = false;
                        _repo.Update(order);
                        return;
                    }
                    if (isBefore == 2)
                    {
                        await _emailService.Send(order.OrderAuthor.Email, "Pedido está proximo de vencer", "Devolva os livros daqui 2 dias na sede em que pegou os livros. PS Se forem apenas virtual desconsidere o email");
                    }
                }
            }
        }
    }
}
