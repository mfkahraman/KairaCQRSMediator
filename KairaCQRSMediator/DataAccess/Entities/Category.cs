using System.ComponentModel.DataAnnotations;

namespace KairaCQRSMediator.DataAccess.Entities
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public IList<Product>? Products { get; set; }
    }
}
