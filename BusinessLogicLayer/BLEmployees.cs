using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
       private IDALEmployees _dal;

        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }

        public void AddEmployee(Employee emp)
        {
            DALEmployeesEF mEmp = new DALEmployeesEF();
            mEmp.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            DALEmployeesEF emp = new DALEmployeesEF();
            emp.DeleteEmployee(id);
        }

        public void UpdateEmployee(Employee emp)
        {
            DALEmployeesEF emp = new DALEmployeesEF();
            return emp.UpdateEmployee(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            DALEmployeesEF emp = new .DALEmployeesEF();
            return emp.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            DALEmployeesEF emp = new DALEmployeesEF();
            if (emp == null)
            {
                throw new Exception("El usuario no se encontro");
            }
            return emp.GetEmployee(id);
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            DALEmployeesEF emp = new DALEmployeesEF();
            if (emp == null)
            {
                throw new Exception("El usuario no se encontro");
            }
            Employee mEmp = emp.GetEmployee(idEmployee);
            if (mEmp.GetType().Name == "FullTimeEmployee")
            {
                throw new Exception("El usuario no es part-time");
            }
            else
            {
                return ((PartTimeEmployee)mEmp).HourlyRate * hours;
            }

        }
    }
}
