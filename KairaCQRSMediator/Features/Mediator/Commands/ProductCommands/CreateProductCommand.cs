﻿using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
