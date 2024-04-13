using basic_api.Data.Repositories;
using basic_api.Data.Services;
using basic_api.Domain.Order.UseCases;

namespace basic_api.Application.Order.UseCases
{
    public class VerifyStatusOrderUsecase(IOrderRepository repo, IEmailService emailService): IVerifyStatusOrderUsecase
    {
        private readonly IOrderRepository _repo = repo;
        private readonly IEmailService _emailService = emailService;
        public async Task Execute()
        {
            var orders = _repo.Get([]);

            foreach (var order in orders)
            {
                if (order.DevolveAt != null && order.Devolved == null)
                {
                    var isBefor = ((DateTime)order.DevolveAt - DateTime.Now).TotalDays;
                    if (isBefor < 0)
                    {
                        await _emailService.Send(order.OrderAuthor.Email, "Pedido está em atraso", $"");
                        order.Devolved = false;
                        _repo.Update(order);
                        return;
                    }
                    if (isBefor == 2)
                    {
                        await _emailService.Send(order.OrderAuthor.Email, "Pedido está proximo de vencer", "Devolva os livros daqui 2 dias na sede em que pegou os livros. PS Se forem apenas virtual desconsidere o email");
                    }
                }
            }
        }
    }
}
