namespace KairaCQRSMediator.Features.CQRS.Results.SubscribeResults
{
    public class GetSubscribesQueryResult
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
}
