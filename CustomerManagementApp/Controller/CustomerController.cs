using System;
using System.Collections.Generic;
using CustomerManagementApp.Model;

namespace CustomerManagementApp.Controller
{
    public class CustomerController
    {
        private List<Customer> customers = new List<Customer>();

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public void AddCustomer(Customer c)
        {
            if (string.IsNullOrEmpty(c.Id) || string.IsNullOrEmpty(c.Name))
                throw new Exception("Customer ID and Name cannot be empty.");
            customers.Add(c);
        }

        public void EditCustomer(string id, string newName)
        {
            var found = customers.Find(c => c.Id == id);
            if (found == null) throw new Exception("Customer not found.");
            found.Name = newName;
        }

        public void RemoveCustomer(string id)
        {
            var found = customers.Find(c => c.Id == id);
            if (found == null) throw new Exception("Customer not found.");
            customers.Remove(found);
        }
    }
}
