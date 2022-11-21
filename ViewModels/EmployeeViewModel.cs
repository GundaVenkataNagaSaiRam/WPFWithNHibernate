using System.Collections.Generic;
using MvvmDemo.Models;

namespace MvvmDemo.ViewModels
{
    public class EmployeeViewModel 
    {
        EmployeeService employeeService;

        public EmployeeViewModel()
        {
            employeeService = new EmployeeService();
            LoadData();
        }

        public void LoadData()
        {
            EmployeeList = employeeService.Get();
        }

        public void SaveOrUpdate(Employee employeeMvvm)
        {
            employeeService.Post(employeeMvvm);
        }

        public Employee Get(int id)
        {
            return employeeService.Get(id);
        }
        public void Delete(Employee employeeMvvm)
        {
            employeeService.Delete(employeeMvvm);
        }

        public List<Employee> EmployeeList { get; set; }
    }
}
