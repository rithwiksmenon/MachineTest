using SalesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Repository
{
    public interface ISalesRepository
    {
        //get all sales employees
        #region get sales
        Task<List<EmployeeRegistration>> GetSalesEmployee();
        #endregion

        //add sales employees
        #region add sales employee
        Task<int> AddSalesEmployee(EmployeeRegistration employee);
        #endregion

        //update sales employees
        #region update sales employee
        Task UpdateSalesEmployee(EmployeeRegistration employee);
        #endregion

        //get sales employees by id
        #region get sales employee by id
        Task<EmployeeRegistration> GetSalesEmployeeById(int id);
        #endregion

        //delete sales employees
        #region delete sales employee
        Task<EmployeeRegistration> DeleteSalesEmployee(int id);
        #endregion


    }
}
