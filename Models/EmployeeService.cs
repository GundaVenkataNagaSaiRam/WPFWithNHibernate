using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;

namespace MvvmDemo.Models
{
    public class EmployeeService
    {
        public List<Employee> Get()
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                try
                {
                    IQuery iQuery = iSession.CreateQuery("FROM Employee");
                    IList<Employee> employees = iQuery.List<Employee>();
                    return employees.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
        public Employee Get(int Id)
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                try
                {
                    IQuery iQuery = iSession.CreateQuery("From Employee where Id = " + Id + "");
                    Employee employee = iQuery.List<Employee>()[0];
                    return employee;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
        public bool Post(Employee employee)
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                using(ITransaction iTransaction = iSession.BeginTransaction())
                {
                    try
                    {
                        iSession.SaveOrUpdate(employee);
                        iTransaction.Commit();                       
                        return true;
                    }
                    catch (Exception ex)
                    {
                        iTransaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false;
                        throw;
                    }
                }
            }
        }
        public bool Delete(Employee employee)
        {
            ISession iSession = SessionFactory.OpenSession;
            using (iSession)
            {
                using(ITransaction iTransaction = iSession.BeginTransaction())
                {
                    try
                    {
                        iSession.Delete(employee);
                        iTransaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        iTransaction.Rollback();
                        Console.WriteLine(ex.Message);
                        return false;
                        throw;
                    }
                }
            }
        }
    }
}
