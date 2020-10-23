using System.Linq;
using ZFramework.Data.Abstract.Attributes;
using ZFramework.Demo.API.Models;
using ZFramework.Demo.DAL.Repositories;

namespace ZFramework.Demo.API.Services.Handlers
{
    [DataService(typeof(IEmployeeService))]
    public class DefaultEmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public DefaultEmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        public void Delete(params object[] keyValues)
            => employeeRepository.Delete(employeeRepository.FindByKey(keyValues));

        public EmployeeListModel Find(params object[] keyValues)
        {
            //=> employeeRepository.FindByKey(keyValues);
            return null;
        }

        public IQueryable<EmployeeListModel> List()
        {
            //=> employeeRepository.List();
            return null;
        }

        public void SaveChanges(EmployeeEditModel entity)
        {
            //if (entity.ID > 0)
            //{
            //    employeeRepository.Update(entity);
            //}
            //else
            //{
            //    employeeRepository.Insert(entity);
            //}
        }
    }
}