using AutoMapper;
using ZFramework.Demo.DAL.BusinessData;
using ZFramework.Modules.API.Security;

namespace ZFramework.Demo.API.Models
{
    public class EmployeeEditModel
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }

    public class EmployeeEditModelProfile : Profile
    {
        public EmployeeEditModelProfile()
        {
            CreateMap<EmployeeEditModel, Employees>()
                .ForMember(x => x.PasswordHash, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.Password));
                    opt.MapFrom(src => PasswordHash.Create(src.ID, src.Password));
                });

            CreateMap<Employees, EmployeeEditModel>()
                .ForMember(x => x.Password, opt =>
                {
                    opt.Ignore();
                });
        }
    }
}