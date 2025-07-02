using System.ComponentModel.DataAnnotations;

namespace KairaCQRSMediator.DataAccess.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
