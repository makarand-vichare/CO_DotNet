using AutoMapper;
using CrossOver.EntityModels.Core;
using CrossOver.EntityModels.Identity;
using CrossOver.EntityModels.SearchBook;
using CrossOver.EntityModels.UserDemand;
using CrossOver.ViewModels;
using CrossOver.ViewModels.Core;
using CrossOver.ViewModels.Identity;
using System.Linq;

namespace CrossOver.IDomainServices.AutoMapper
{
    public class ModelAutoMapperProfiler : Profile
    {
        public ModelAutoMapperProfiler()
        {
           CreateMap<BaseEntityModel, BaseViewModel>().ReverseMap();
           //CreateMap<AuditableEntityModel, AuditableViewModel>().ReverseMap();

           CreateMap<UserEntityModel, IdentityUserViewModel>().ReverseMap();
           
            CreateMap<RoleEntityModel, IdentityRoleViewModel>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));
           CreateMap<IdentityRoleViewModel, RoleEntityModel>()
                            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));

           CreateMap<BookEntityModel, BookViewModel>()
                .ForMember(dest => dest.Authors, src => src.ResolveUsing<ListCommaSeparatedStringResolver, string[]>(s => s.Authors.ToArray()))
                .ReverseMap();

            CreateMap<UserDemandEntityModel, UserDemandViewModel>().ReverseMap();

            CreateMap<RefreshTokenEntityModel, RefreshTokenViewModel>().ReverseMap();

        }
    }
}
