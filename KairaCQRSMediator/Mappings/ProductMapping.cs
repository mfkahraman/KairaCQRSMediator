﻿using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.ProductCommands;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;

namespace KairaCQRSMediator.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, GetProductsQueryResult>().ReverseMap();   
            CreateMap<Product, CreateProductCommand>().ReverseMap();   
            CreateMap<Product, UpdateProductComand>().ReverseMap();   
            CreateMap<Product, GetProductByIdQueryResult>().ReverseMap();   
            CreateMap<GetProductByIdQueryResult, UpdateProductComand>().ReverseMap();   
        }
    }
}
