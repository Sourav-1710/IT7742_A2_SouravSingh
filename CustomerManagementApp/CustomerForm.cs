using System;
using System.Windows.Forms;
using System.Xml.Linq;
using CustomerManagementApp.Controller;
using CustomerManagementApp.Model;

namespace CustomerManagementApp
{
    public partial class CustomerForm : Form
    {
        private CustomerController controller = new CustomerController();

        public CustomerForm()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = controller.GetAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                controller.AddCustomer(new Customer(txtId.Text, txtName.Text));
                DisplayData();
                ClearFields();
                MessageBox.Show("Customer added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                controller.EditCustomer(txtId.Text, txtName.Text);
                DisplayData();
                ClearFields();
                MessageBox.Show("Customer updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                controller.RemoveCustomer(txtId.Text);
                DisplayData();
                ClearFields();
                MessageBox.Show("Customer deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Customer Management App\nVersion 1.0\nSimple MVC Example", "About");
        }
    }
}
