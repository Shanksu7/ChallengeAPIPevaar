using AutoMapper;
using ChallengeDataObjects.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAPIPevaar.Models
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDetailModel>()
            .ForMember(dest =>
               dest.Type,
                opt => opt.MapFrom(src => src.TypeNavigation.Name.ToString()));

            CreateMap<ProductEntryModel, Product>()
            .ForMember(dest =>
               dest.Type,
                opt => opt.MapFrom(src => (int) src.Type));

        }
    }
}
