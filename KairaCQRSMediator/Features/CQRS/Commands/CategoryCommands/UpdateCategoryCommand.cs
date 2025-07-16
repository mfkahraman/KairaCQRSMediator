namespace KairaCQRSMediator.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
