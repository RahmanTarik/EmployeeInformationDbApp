using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using EmployeeInformationDbApp.BLL;
using EmployeeInformationDbApp.Model;

namespace EmployeeInformationDbApp.UI
{
    public partial class EmployeeInfoUi : Form
    {
        public EmployeeInfoUi()
        {
            InitializeComponent();
        }

        EmployeeManager manager = new EmployeeManager();
        private int _employeeId = 0;
        private void saveButton_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (nameTextBox.Text != String.Empty && emailTextBox.Text != String.Empty && addressTextBox.Text != String.Empty && salaryTextBox.Text != String.Empty)
            {
                Employee aEmployee = new Employee();
                aEmployee.name = nameTextBox.Text.Trim();
                aEmployee.email = emailTextBox.Text.Trim();
                aEmployee.address = addressTextBox.Text.Trim();
                aEmployee.salary = Convert.ToDecimal(salaryTextBox.Text);
                msg = manager.Save(aEmployee);
                MessageBox.Show(msg);
                ShowAllEmployee();
                ClearText();
            }
            else
            {
                if (nameTextBox.Text ==String.Empty)
                {
                    msg = "Please Enter Your Name";
                }
                else if (emailTextBox.Text ==String.Empty)
                {
                    msg = "Please Enter Your Email";
                }
                else if (addressTextBox.Text == String.Empty)
                {
                    msg = "Please Enter Your Address";
                }
                else if (salaryTextBox.Text == String.Empty)
                {
                    msg = "Please Enter Your Salary\n";
                }
                else
                {
                    msg = "Please Enter Information";
                }
                
                MessageBox.Show(msg);
            }
            

        }

        List<Employee> employees = new List<Employee>(); 
        private void ShowAllEmployee()
        {
            employees.Clear();
            employees = manager.GetAllEmployees();
            employeeListView.Items.Clear();
            foreach (Employee employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.Id.ToString());
                item.SubItems.Add(employee.name);
                item.SubItems.Add(employee.email);
                item.SubItems.Add(employee.address);
                item.SubItems.Add(employee.salary.ToString());
                employeeListView.Items.Add(item);
            }
        }

        private void ClearText()
        {
            nameTextBox.Clear();
            emailTextBox.Clear();
            addressTextBox.Clear();
            salaryTextBox.Clear();
        }

        private void EmployeeInfoUi_Load(object sender, EventArgs e)
        {
            ShowAllEmployee();
        }

        private void employeeListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (employeeListView.SelectedItems.Count > 0)
            {
                ListViewItem firstSelectedListViewItem = employeeListView.SelectedItems[0];
                int employeeId = int.Parse(firstSelectedListViewItem.Text);

                Employee employee = manager.GetEmployeeById(employeeId);
                nameTextBox.Text = employee.name;
                emailTextBox.Text = employee.email;
                addressTextBox.Text = employee.address;
                salaryTextBox.Text = employee.salary.ToString();

                this._employeeId = employee.Id;
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (nameTextBox.Text != String.Empty && emailTextBox.Text != String.Empty &&
                addressTextBox.Text != String.Empty && salaryTextBox.Text != String.Empty)
            {
                Employee aEmployee = new Employee();
                aEmployee.Id = _employeeId;
                aEmployee.name = nameTextBox.Text;
                aEmployee.email = emailTextBox.Text;
                aEmployee.address = addressTextBox.Text;
                aEmployee.salary = decimal.Parse(salaryTextBox.Text);

                MessageBox.Show(manager.Update(aEmployee));
                ShowAllEmployee();
                ClearText();
            }
            else
            {
                msg = "Please Select Emplyee First\n";
                MessageBox.Show(msg);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
             string msg = "";
            if (nameTextBox.Text != String.Empty && emailTextBox.Text != String.Empty &&
                addressTextBox.Text != String.Empty && salaryTextBox.Text != String.Empty)
            {
                Employee aEmployee = new Employee();
                aEmployee.Id = _employeeId;
                aEmployee.name = nameTextBox.Text;
                aEmployee.email = emailTextBox.Text;
                aEmployee.address = addressTextBox.Text;
                aEmployee.salary = decimal.Parse(salaryTextBox.Text);

                MessageBox.Show(manager.Delete(aEmployee));
                ShowAllEmployee();
                ClearText();
            }
            else
            {
                msg = "Please Select Emplyee First";
                MessageBox.Show(msg);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            string searchName = searchNameTextBox.Text;
            employeeListView.Items.Clear();
            
            foreach (Employee employee in employees)
            {
                if (employee.name.ToLower().Contains(searchName))
                {
                    ListViewItem item = new ListViewItem(employee.Id.ToString());
                    item.SubItems.Add(employee.name);
                    item.SubItems.Add(employee.email);
                    item.SubItems.Add(employee.address);
                    item.SubItems.Add(employee.salary.ToString());
                    employeeListView.Items.Add(item);
                    count++;
                }
            }
            if (count==0)
            {
                MessageBox.Show("Name not Found");
            }
        }
        
    }
}
