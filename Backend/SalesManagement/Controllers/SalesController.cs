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
    public class SalesController : ControllerBase
    {
        //Constructor Dependency Injection for salesRepository
        //1.Default constructor - salesController
        //2.IsalesRepository

        ISalesRepository salesRepository;
        public SalesController(ISalesRepository _p)
        {
            salesRepository = _p;
        }

        //get sales employee
        #region get sales employee
        [HttpGet]
        //[Route("GetSalesEmployee")]
        public async Task<IActionResult> GetSalesEmployee()
        {
            try
            {
                var emp = await salesRepository.GetSalesEmployee();
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
        #endregion

        //add sales employee
        #region add sales employee
        [HttpPost]
        //[Route("AddSalesEmployee")]
        public async Task<IActionResult> AddSalesEmployee([FromBody] EmployeeRegistration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeId = await salesRepository.AddSalesEmployee(model);
                    if (employeeId > 0)
                    {
                        return Ok(employeeId);
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

        //update sales employee
        #region update sales employee
        [HttpPut]
        //[Route("UpdateSalesEmployee")]
        public async Task<IActionResult> UpdateSalesEmployee([FromBody] EmployeeRegistration model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await salesRepository.UpdateSalesEmployee(model);
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

        //delete sales employee
        #region delete sales employee
        [HttpDelete]
        //[Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteSalesEmployee(int id)
        {
            try
            {
                var emp = await salesRepository.DeleteSalesEmployee(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //get sales employee by id
        #region sales employee by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesEmployeeById(int id)
        {
            try
            {
                var emp = await salesRepository.GetSalesEmployeeById(id);
                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);
            }
           catch (Exception)
            {
                return BadRequest();

            }
        }
        #endregion
    }
}
