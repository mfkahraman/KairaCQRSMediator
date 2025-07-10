using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.ProductCommands
{
    public class RemoveProductCommand(int id) : IRequest<bool>
    {
        public int Id { get; set; } = id;
    }
}
