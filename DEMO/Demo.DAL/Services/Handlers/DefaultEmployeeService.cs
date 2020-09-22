using System.Linq;
using ZFramework.Data.Abstract.Attributes;
using ZFramework.Demo.DAL.BusinessData;
using ZFramework.Demo.DAL.Repositories;

namespace ZFramework.Demo.DAL.Services.Handlers
{
    [DataService(typeof(IDefaultEmployeeService))]
    public class DefaultEmployeeService : IDefaultEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public DefaultEmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        public void Delete(params object[] keyValues)
            => employeeRepository.Delete(employeeRepository.FindByKey(keyValues));

        public Employees Find(params object[] keyValues)
            => employeeRepository.FindByKey(keyValues);

        public IQueryable<Employees> List()
            => employeeRepository.List();

        public void SaveChanges(Employees entity)
        {
            if (entity.ID > 0)
            {
                employeeRepository.Update(entity);
            }
            else
            {
                employeeRepository.Insert(entity);
            }
        }
    }
}