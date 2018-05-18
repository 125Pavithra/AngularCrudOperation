using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeAngular.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        EmployeeDatabaseEntities em = new EmployeeDatabaseEntities();

        //Get Method
        [HttpGet]
        [Route("api/Employee")]  
        public IEnumerable<EmployeeTBLE> GetEmployee()
        {
            return em.EmployeeTBLEs.ToList();
        }

        //Get by Id
        [HttpGet]
        [Route("api/Employee/{employeeId}")]
        public EmployeeTBLE GetEmployeeById(int employeeId)
         {

            var res = em.EmployeeTBLEs.Where(x => x.EmployeeId == employeeId).SingleOrDefault();
            return res;
        }

        [HttpPost]
        [Route("api/Employee")]
        public void Post(EmployeeTBLE Employee)
        {
            em.EmployeeTBLEs.Add(Employee);
            em.SaveChanges();
        }
        [HttpPut]
        [Route("api/Employee/UpdateEmployeeById/{employeeId}")]
        public void UpdateEmployeeById(int employeeId, EmployeeTBLE Employee)
        {
            var selectedEmployee = em.EmployeeTBLEs.FirstOrDefault(x => x.EmployeeId == employeeId);
            selectedEmployee.Name = Employee.Name;
            selectedEmployee.City = Employee.City;
            selectedEmployee.Department = Employee.Department;
            selectedEmployee.Gender = Employee.Gender;
            em.SaveChanges();
        }
        [HttpDelete]
        [Route("api/Employee/DeleteEmployeeById/{employeeId}")]
        public void DeleteEmployeeById(int employeeId)
        {
            var deleteEmployee = em.EmployeeTBLEs.FirstOrDefault(x => x.EmployeeId == employeeId);
            em.EmployeeTBLEs.Remove(deleteEmployee);
            em.SaveChanges();
        }

    }
}
