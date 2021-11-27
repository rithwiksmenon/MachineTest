using Microsoft.EntityFrameworkCore;
using SalesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Repository
{
    public class Salesrepository : ISalesRepository
    {
        //database/json
        SalesDBContext db;

        //Constructor dependency injection
        public Salesrepository(SalesDBContext _db)
        {
            db = _db;
        }

        //add sales employee
        #region add sales employee
        public async Task<int> AddSalesEmployee(EmployeeRegistration employee)
        {
            if (db != null)
            {
                await db.EmployeeRegistration.AddAsync(employee);
                await db.SaveChangesAsync();//commit the transaction
                return employee.EmpId;
            }
            return 0;
        }
        #endregion

        //delete sales employee
        #region delete sales employee
        public async Task<EmployeeRegistration> DeleteSalesEmployee(int id)
        {
            if (db != null)
            {
                EmployeeRegistration dbemp = db.EmployeeRegistration.Find(id);
                db.EmployeeRegistration.Remove(dbemp);
                await db.SaveChangesAsync();
                return (dbemp);
            }

            return null;
        }
        #endregion

        //get sales employee
        #region get sales employee
        public async Task<List<EmployeeRegistration>> GetSalesEmployee()
        {
            if (db != null)
            {
                return await db.EmployeeRegistration.ToListAsync();
            }
            return null;
        }
        #endregion

        //get sales employee by id
        #region get sales employee by id
        public async Task<EmployeeRegistration> GetSalesEmployeeById(int id)
        {
            
                if (db != null)
                {
                    EmployeeRegistration emp = await db.EmployeeRegistration.FindAsync(id);
                    return emp;

                }
                return null;           
        }
        #endregion

        //update sales employee
        #region update sales employee
        public async Task UpdateSalesEmployee(EmployeeRegistration employee)
        {
            if (db != null)
            {
                db.EmployeeRegistration.Update(employee);
                await db.SaveChangesAsync();//commit the transaction

            }
        }
        #endregion
    }
}
