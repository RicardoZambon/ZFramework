using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading.Tasks;
using ZFramework.Data.Abstract.Attributes;
using ZFramework.Data.EfCore;
using ZFramework.Demo.API.Models;
using ZFramework.Demo.DAL.Repositories;

namespace ZFramework.Demo.API.Services.Handlers
{
    [DataService(typeof(IEmployeeService))]
    public class DefaultEmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly ZDbContext DbContext;
        private readonly IMapper Mapper;

        public DefaultEmployeeService(IEmployeeRepository employeeRepository, ZDbContext dbContext, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }


        public IQueryable<EmployeeListModel> List()
            => employeeRepository.List().ProjectTo<EmployeeListModel>(Mapper.ConfigurationProvider);

        public async Task UpdateAsync(EmployeeEditModel model)
        {
            var employee = await employeeRepository.FindByKeyAsync(model.ID);

            Mapper.Map(model, employee);

            employeeRepository.Update(employee);
            await DbContext.SaveChangesAsync();
        }

        //public void Delete(params object[] keyValues)
        //    => employeeRepository.Delete(employeeRepository.FindByKey(keyValues));

        //public EmployeeListModel Find(params object[] keyValues)
        //{
        //    //=> employeeRepository.FindByKey(keyValues);
        //    return null;
        //}

        //public IQueryable<EmployeeListModel> List()
        //{
        //    //=> employeeRepository.List();
        //    return null;
        //}


        //public void SaveChanges(EmployeeEditModel entity)
        //{
        //    //if (entity.ID > 0)
        //    //{
        //    //    employeeRepository.Update(entity);
        //    //}
        //    //else
        //    //{
        //    //    employeeRepository.Insert(entity);
        //    //}
        //}
    }
}