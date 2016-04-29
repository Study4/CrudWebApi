using CrudWebApi.Api.Model.Dtos;
using CrudWebApi.Api.Services;
using CrudWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CrudWebApi.Api.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private IEmployeeService _service;

        public EmployeesController(IEmployeeService s)
        {
            _service = s;
        }

        [ResponseType(typeof(IQueryable<EmployeeDto>))]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // Get ID
        [ResponseType(typeof(EmployeeDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var obj = await _service.GetAllAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        // PUT
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dto.EmployeeID)
            {
                return BadRequest();
            }

            var result = await _service.SaveAsync(dto);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // POST
        [ResponseType(typeof(EmployeeDto))]
        public async Task<IHttpActionResult> Post(EmployeeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.SaveAsync(dto);

            return CreatedAtRoute("DefaultApi", new { id = result.EmployeeID }, result);
        }

        // DELETE
        [ResponseType(typeof(EmployeeDto))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
