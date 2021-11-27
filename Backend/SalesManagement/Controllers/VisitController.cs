using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagement.Models;
using SalesManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        //Constructor Dependency Injection for visitRepository
        //1.Default constructor - visitController
        //2.IvisitRepository

        IVisitRepository visitRepository;
        public VisitController(IVisitRepository _p)
        {
            visitRepository = _p;
        }

        //add visit
        #region add visit
        [HttpPost]
       // [Route("AddEmployee")]
        public async Task<IActionResult> AddVisit([FromBody] VisitTbale model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var visitId = await visitRepository.AddVisit(model);
                    if (visitId > 0)
                    {
                        return Ok(visitId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //update visit
        #region update visit
        [HttpPut]
        //[Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateVisit([FromBody] VisitTbale model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.UpdateVisit(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        //get visit
        #region get visit
        [HttpGet]
        //[Route("GetAllEmployees")]
        public async Task<IActionResult> GetVisit()
        {
            try
            {
                var visit = await visitRepository.GetVisit();
                if (visit == null)
                {
                    return NotFound();
                }
                return Ok(visit);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
        #endregion

        //get visit by id
        #region get visit by id
        [HttpGet]
        //[Route("GetEmployeeById")]
        public async Task<IActionResult> GetVisitById(int id)
        {
            try
            {
                var visit = await visitRepository.GetVisitById(id);
                if (visit == null)
                {
                    return NotFound();
                }
                return Ok(visit);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        //delete visit 
        #region delete visit
        [HttpDelete]
        //[Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            try
            {
                var visit = await visitRepository.DeleteVisit(id);
                if (visit == null)
                {
                    return NotFound();
                }
                return Ok(visit);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion


    }
}
