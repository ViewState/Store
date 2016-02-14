using System;
using AutoMapper;
using Store.Model;
using Store.Web.ViewModels;

namespace Store.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override String ProfileName => "DomainToViewModelMappings";

        protected override void Configure()
        {
            CreateMap<Gadget, GadgetViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}