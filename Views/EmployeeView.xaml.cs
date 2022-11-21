using MvvmDemo.Models;
using MvvmDemo.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace MvvmDemo.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl , INotifyPropertyChanged
    {
        EmployeeViewModel employeeViewModel; 
        public EmployeeView()
        {
            InitializeComponent();
            employeeViewModel = new EmployeeViewModel();
            this.DataContext = employeeViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        Window window = new Window();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtId.Text == "" || txtId.Text == null)
            {
                Employee employeeMvvm = new Employee();
                employeeMvvm.FirstName = txtFirstName.Text;
                employeeMvvm.LastName = txtLastName.Text;
                employeeMvvm.Email = txtEmail.Text;
                employeeViewModel = new EmployeeViewModel();
                employeeViewModel.SaveOrUpdate(employeeMvvm);

                ClearForm();

                employeeViewModel.LoadData();
                
                window.Close();
            }
            else
            {
                Employee employeeMvvm = new Employee();
                employeeMvvm.Id = Convert.ToInt32(txtId.Text);
                employeeMvvm.FirstName = txtFirstName.Text;
                employeeMvvm.LastName = txtLastName.Text;
                employeeMvvm.Email = txtEmail.Text;
                employeeViewModel = new EmployeeViewModel();
                employeeViewModel.SaveOrUpdate(employeeMvvm);

                ClearForm();
                window.Close();
            }
        }

        private void dgEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtId.Text = ((Employee)e.AddedItems[0]).Id.ToString();
            txtFirstName.Text = ((Employee)e.AddedItems[0]).FirstName.ToString();
            txtLastName.Text = ((Employee)e.AddedItems[0]).LastName.ToString();
            txtEmail.Text = ((Employee)e.AddedItems[0]).Email.ToString();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            Employee employeeMvvm = employeeViewModel.Get(id);

            txtId.Text = employeeMvvm.Id.ToString();
            txtFirstName.Text = employeeMvvm.FirstName;
            txtLastName.Text = employeeMvvm.LastName;
            txtEmail.Text = employeeMvvm.Email;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee employeeMvvm = new Employee();
            employeeMvvm.Id = Convert.ToInt32(txtId.Text);
            employeeMvvm.FirstName = txtFirstName.Text;
            employeeMvvm.LastName = txtLastName.Text;
            employeeMvvm.Email = txtEmail.Text;

            employeeViewModel.Delete(employeeMvvm);

            ClearForm();
            window.Close();
        }

        public void ClearForm()
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
        }       
    }
}
