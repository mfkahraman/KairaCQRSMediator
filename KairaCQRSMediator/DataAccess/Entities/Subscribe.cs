namespace KairaCQRSMediator.DataAccess.Entities
{
    public class Subscribe : IEntity
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }

    }
}
