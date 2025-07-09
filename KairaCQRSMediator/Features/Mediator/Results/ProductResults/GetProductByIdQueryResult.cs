﻿using KairaCQRSMediator.Features.CQRS.Results.CategoryResults;

namespace KairaCQRSMediator.Features.Mediator.Results.ProductResults
{
    public class GetProductByIdQueryResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public GetCategoryQueryResult? Category { get; set; }
    }
}
