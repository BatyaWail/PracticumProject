using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Entities;

namespace EmployeeServer.Api
{
    public class PostModelsMapping : Profile
    {
        public PostModelsMapping()
        {

            //CreateMap<EmployeePostModel, Employee>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore mapping Id from EmployeePostModel
            //    .ForMember(dest => dest.EmployeeRoles, opt => opt.MapFrom(src => src.EmployeeRoles));

            //CreateMap<EmployeeRolePostModel, EmployeeRole>()
            //    .ForMember(dest => dest.EmployeeId, opt => opt.Ignore()) // Ignore mapping EmployeeId from EmployeeRolePostModel
            //    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.RoleId))
            //    .ForMember(dest => dest.EntryDate, opt => opt.MapFrom(src => src.EntryDate));

            //CreateMap<RolePostModel, Role>(); // Simple mapping for Role
            //CreateMap<LoginModel, User>();
            CreateMap<EmployeePostModel, Employee>();


            CreateMap<EmployeeRolePostModel, EmployeeRole>();
               

            CreateMap<RolePostModel, Role>(); // Simple mapping for Role
            CreateMap<LoginModel, Company>();
            CreateMap<CompanyPostModel, Company>();
            CreateMap<CompanyToPost, Company>();

        }

    }
}
