﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Services
{
    public class CustomerService : ICustomerService
    {
        private IList<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer(1, "Tina"));
            _customers.Add(new Customer(2, "Bing"));
            _customers.Add(new Customer(3, "Eillen"));
            _customers.Add(new Customer(4, "Jamie"));
        }

        public Customer GetCustomerById(int id)
        {
            return GetCustomerByIdAsync(id).Result;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return Task.FromResult(_customers.Single(o => Equals
              (o.Id, id)));
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(_customers.AsEnumerable());
        }
    }

    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
