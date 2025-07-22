namespace KairaCQRSMediator.Features.CQRS.Commands.SubscribeCommands
{
    public class CreateSubscribeCommand
    {
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
}
