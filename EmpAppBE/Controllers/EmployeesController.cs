using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmpAppBE.Models;
using System.Web.Http.Cors;
using EmpAppBE.Repositories;

namespace EmpAppBE.Controllers
{
    // Enabling Cross-Origin Requests (CORS) for all controller methods
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class EmployeesController : ApiController
    {
        EmployeeUOW _employeeUOW = new EmployeeUOW();

        private EmpDBEntities db = new EmpDBEntities();

        // GET: api/Employees
        [Route("api/v1/employees")]
        public IQueryable<employee> Getemployees()
        {
            return _employeeUOW.GetAll();
        }

        // GET: api/Employees/5
        [Route("api/v1/employees/{id}", Name = "GetEmployeeByID")]
        [ResponseType(typeof(employee))]
        public employee Getemployee(int id)
        {
            return _employeeUOW.GetSingle(id);
            //employee employee = db.employees.Find(id);
            //if (employee == null)
            //{
            //    return NotFound();
            //}

            //return Ok(employee);
        }

        // PUT: api/Employees/5
        [Route("api/v1/employees/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putemployee(int id, employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [HttpPost, Route("api/v1/employees")]
        [ResponseType(typeof(employee))]
        public HttpResponseMessage Postemployee(employee employee)
        {
            // Validate and add employee to database
            if (employee == null)
            {
                var message = string.Format("Employee data can not be null.");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, message);
            }

            try {
                db.employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex) {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

            // Create response for sucess
            var response = Request.CreateResponse(HttpStatusCode.Created, employee);

            // Generate a link to the new book and set the Location header in the response.
            string uri = Url.Link("GetEmployeeByID", new { id = employee.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // DELETE: api/Employees/5
        [Route("api/v1/employees/{id}")]
        [ResponseType(typeof(employee))]
        public IHttpActionResult Deleteemployee(int id)
        {
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool employeeExists(int id)
        {
            return db.employees.Count(e => e.id == id) > 0;
        }
    }
}