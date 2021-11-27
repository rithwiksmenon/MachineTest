using Microsoft.EntityFrameworkCore;
using SalesManagement.Models;
using SalesManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Repository
{
    public class VisitRepository : IVisitRepository
    {
       
            //database/json
            SalesDBContext db;

            //Constructor dependency injection
            public VisitRepository(SalesDBContext _db)
            {
                db = _db;
            }


        //add visit
        #region add visit
        public async Task<int> AddVisit(VisitTbale visit)
        {
            if (db != null)
            {
                await db.VisitTbale.AddAsync(visit);
                await db.SaveChangesAsync();//commit the transaction
                return visit.VisitId;
            }
            return 0;
        }
        #endregion

        //delete visit
        #region delete visit
        public async Task<VisitTbale> DeleteVisit(int id)
        {
            if (db != null)
            {
                VisitTbale dbvisit = db.VisitTbale.Find(id);
                db.VisitTbale.Remove(dbvisit);
                await db.SaveChangesAsync();
                return (dbvisit);
            }

            return null;
        }
        #endregion

        //get visit details
        #region get visit details
        public async Task<List<SalesViewModel>> GetVisit()
        {
            if (db != null)
            {
                //LINQ
                return await(from v in db.VisitTbale
                             from e in db.EmployeeRegistration
                             where v.EmpId == e.EmpId
                             select new SalesViewModel
                             {
                                 VisitId=v.VisitId,
                                 CustName=v.CustName,
                                 ContactPerson=v.ContactPerson,
                                 ContactNo=v.ContactNo,
                                 InterestProduct=v.InterestProduct,
                                 VisitSubject=v.VisitSubject,
                                 Description=v.Description,
                                 VisitDatetime=v.VisitDatetime,
                                 IsDisabled=v.IsDisabled,
                                 IsDeleted=v.IsDeleted,
                                 EmpId=e.EmpId,
                                 FirstName=e.FirstName

                             }
                             ).ToListAsync();
            }
            return null;
        }
        #endregion

        //get visit by id
        #region get visit by id
        public async Task<SalesViewModel> GetVisitById(int id)
        {
            if (db != null)
            {
                //LINQ
                //join post and category



                return await(from v in db.VisitTbale
                             from e in db.EmployeeRegistration
                             where v.VisitId == id && v.EmpId == e.EmpId
                             select new SalesViewModel
                             {
                                 VisitId = v.VisitId,
                                 CustName = v.CustName,
                                 ContactPerson = v.ContactPerson,
                                 ContactNo = v.ContactNo,
                                 InterestProduct = v.InterestProduct,
                                 VisitSubject = v.VisitSubject,
                                 Description = v.Description,
                                 VisitDatetime = v.VisitDatetime,
                                 IsDisabled = v.IsDisabled,
                                 IsDeleted = v.IsDeleted,
                                 EmpId = e.EmpId,
                                 FirstName = e.FirstName

                             }).FirstOrDefaultAsync();


            }
            return null;
        }
        #endregion

        //update visit
        #region update visit
        public async Task UpdateVisit(VisitTbale visit)
        {
            if (db != null)
            {
                db.VisitTbale.Update(visit);
                await db.SaveChangesAsync();//commit the transaction

            }
        }
        #endregion
    }
}
