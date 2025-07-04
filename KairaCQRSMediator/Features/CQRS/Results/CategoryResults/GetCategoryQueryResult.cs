﻿using KairaCQRSMediator.Features.Mediator.Results.ProductResults;

namespace KairaCQRSMediator.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryQueryResult
    {
        public required int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public IList<GetProductsQueryResult>? Products { get; set; }

    }
}
