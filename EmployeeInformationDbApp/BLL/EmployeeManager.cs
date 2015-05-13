using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInformationDbApp.DAL;
using EmployeeInformationDbApp.Model;

namespace EmployeeInformationDbApp.BLL
{

    public class EmployeeManager
    {
        EmployeeGateway aGateway = new EmployeeGateway();

        public string Save(Employee aEmployee)
        {
            bool isExists = GetEmployeeByEmail(aEmployee.email);

            if (isExists)
            {
                return "Email Already Exists";
            }
            else
            {
                int value = aGateway.Save(aEmployee);

                if (value > 0)
                {
                    return "Employee Saved";
                }
                else
                {
                    return "Failed to save employee";
                }
            }

        }

        public string Update(Employee aEmployee)
        {

            int value = aGateway.Update(aEmployee);
                if (value > 0)
                {
                    return "Update Successfull";
                }
                else
                {
                    return "Failed to Update";
                }
            }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee aEmployee = aGateway.GetEmployeeById(employeeId);
            return aEmployee;

        }
        public bool GetEmployeeByEmail(string email)
        {
            Employee aEmployee = aGateway.GetEmployeeByEmail(email);
            if (aEmployee != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Employee> GetAllEmployees()
        {
            return aGateway.GetAllEmployee();
        }


        public string Delete(Employee aEmployee)
        {
            int value = aGateway.Delete(aEmployee);
            if (value > 0)
            {
                return "Delete Successfull";
            }
            else
            {
                return "Failed to Delete";
            }

        }
    }
}
