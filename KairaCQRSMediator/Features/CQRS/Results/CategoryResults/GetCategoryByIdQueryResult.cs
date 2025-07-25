﻿using KairaCQRSMediator.DataAccess.Entities;

namespace KairaCQRSMediator.Features.CQRS.Results.CategoryResults
{
    public class GetCategoryByIdQueryResult
    {
        public required int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
