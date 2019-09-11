using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        private Model.EmployeesTPH cast(Employee emp)
        {
            if (emp == null)
            {
                return null;
            }
            if (emp.GetType().Name == "FullTimeEmployee")
            {
                FullTimeEmployee employee = (FullTimeEmployee)emp;
                Model.FullTimeEmployees employeeBase = new Model.FullTimeEmployees()
                {
                    name = employee.Name,
                    StartDate = employee.StartDate,
                    Salary = employee.Salary
                };
                return employeeBase;
            }
            else
            {
                PartTimeEmployee employee = (PartTimeEmployee)emp;
                Model.PartTimeEmployees employeeBase = new Model.PartTimeEmployees()
                {
                    name = employee.Name,
                    StartDate = employee.StartDate,
                    HourlyRate = employee.HourlyRate
                };
                return employeeBase;
            }

        }

        private Employee cast(Model.EmployeesTPH emp)
        {
            if (emp == null)
            {
                return null;
            }
            if (emp.GetType().Name == "FullTimeEmployee")
            {
                Model.FullTimeEmployees employee = (Model.FullTimeEmployees)emp;
                FullTimeEmployee employeeBase = new FullTimeEmployee()
                {
                    Id = employee.EmployeeId,
                    Name = employee.name,
                    StartDate = employee.StartDate,
                    Salary = employee.Salary
                };
                return employeeBase;
            }
            else
            {
                Model.PartTimeEmployees employee = (Model.PartTimeEmployees)x;
                PartTimeEmployee employeeBase = new PartTimeEmployee()
                {
                    Id = employee.EmployeeId,
                    Name = employee.name,
                    StartDate = employee.StartDate,
                    HourlyRate = employee.HourlyRate
                };
                return employeeBase;
            }

        }

        public void AddEmployee(Employee emp)
        {
            if (emp == null)
            {
                return;
            }
            using (Model.Obligatorio1Entities en = new Model.Obligatorio1Entities())
            {
                en.EmployeesTPH.Add(cast(emp));
                en.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (Model.Obligatorio1Entities en = new Model.Obligatorio1Entities())
            {
                en.EmployeesTPH.Remove(
                    en.EmployeesTPH.Find(id)
                );
                en.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            if (emp == null)
            {
                return;
            }
            using (Model.Obligatorio1Entities en = new Model.Obligatorio1Entities())
            {
                Model.EmployeesTPH em = en.EmployeesTPH.Find(emp.Id);
                em.name = emp.Name;
                em.StartDate = emp.StartDate;
                if (emp.GetType().Name == "FullTimeEmployee")
                {
                    Model.FullTimeEmployees emCast = (Model.FullTimeEmployees)em;
                    emCast.Salary = ((FullTimeEmployee)emp).Salary;
                }
                else
                {
                    Model.PartTimeEmployees emCast = (Model.PartTimeEmployees)em;
                    emCast.HourlyRate = ((PartTimeEmployee)emp).HourlyRate;
                }
                en.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (Model.Obligatorio1Entities en = new Model.Obligatorio1Entities())
            {
                List<Employee> listaEmpleados = new List<Employee>();
                en.EmployeesTPH.ToList().ForEach(x =>
                {
                    listaEmpleados.Add(cast(x));
                });
                return listaEmpleados;
            }
        }

        public Employee GetEmployee(int id)
        {
            using (Model.Obligatorio1Entities en = new Model.Obligatorio1Entities())
            {
                return cast(en.EmployeesTPH.Find(id));
            }
        }
    }
}
