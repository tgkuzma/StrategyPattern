using System;
using System.Collections.Generic;
using Business.Interfaces;
using Models;

namespace Business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer GetCustomerByName(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentException("customerName is required.");
            }

            return _customerRepository.GetByCustomerName(customerName);
        }

        public void AddCustomer(Customer customerToAdd)
        {
            _customerRepository.Add(customerToAdd);
            _customerRepository.SaveChanges();
        }

        public void DeleteCustomer(Customer customerToDelete)
        {
            _customerRepository.Delete(customerToDelete);
            _customerRepository.SaveChanges();
        }

        public void UpdateCustomer()
        {
            _customerRepository.SaveChanges();
        }

        public int GetCustomerDuration(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
            {
                throw new ApplicationException(string.Format("A customer with Id {0} does not exist", customerId));
            }

            return _customerRepository.GetCustomerDuration(customer.CustomerName);
        }

        public int GetCustomerDuration(string customerName)
        {
            return _customerRepository.GetCustomerDuration(customerName);
        }
    }
}