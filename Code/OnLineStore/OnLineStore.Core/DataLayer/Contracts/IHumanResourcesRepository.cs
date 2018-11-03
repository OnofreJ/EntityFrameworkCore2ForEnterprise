using System.Linq;
using System.Threading.Tasks;
using OnLineStore.Core.EntityLayer.HumanResources;

namespace OnLineStore.Core.DataLayer.Contracts
{
    public interface IHumanResourcesRepository : IRepository
    {
        IQueryable<Employee> GetEmployees(int pageSize = 10, int pageNumber = 1);

        Task<Employee> GetEmployeeAsync(Employee entity);
    }
}
