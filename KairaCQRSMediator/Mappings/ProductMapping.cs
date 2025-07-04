﻿using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;

namespace KairaCQRSMediator.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, GetProductsQueryResult>().ReverseMap();   
        }
    }
}
