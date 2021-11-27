using SalesManagement.Models;
using SalesManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Repository
{
    public interface IVisitRepository
    {
        //get visit details
        #region get visit details
        Task<List<SalesViewModel>> GetVisit();
        #endregion

        //add visit details
        #region add visit details
        Task<int> AddVisit(VisitTbale visit);
        #endregion

        //update visit details
        #region update visit details
        Task UpdateVisit(VisitTbale visit);
        #endregion

        //get visit details by id
        #region get visit details by id
        Task<SalesViewModel> GetVisitById(int id);
        #endregion

        //delete visit details 
        #region delete visit details 
        Task<VisitTbale> DeleteVisit(int id);
        #endregion
    }
}
