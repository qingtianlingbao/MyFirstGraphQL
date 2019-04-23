using System;
using System.Collections.Generic;
using System.Text;
using Orders.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class OrderService : IOrderService
    {
        private IList<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
            _orders.Add(new Order("1", "A", DateTime.Now, 1, "0-0-0-1"));
            _orders.Add(new Order("2", "B", DateTime.Now.AddHours(1), 2, "0-0-0-2"));
            _orders.Add(new Order("3", "C", DateTime.Now.AddHours(2), 3, "0-0-0-3"));
            _orders.Add(new Order("4", "D", DateTime.Now.AddHours(3), 4, "0-0-0-4"));
            _orders.Add(new Order("5", "E", DateTime.Now.AddHours(4), 5, "0-0-0-5"));
        }

        public Task<Order> GetOrderByIdAsync(string id)
        {
            return Task.FromResult(_orders.Single(o => Equals(o.Id, id)));
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        private Order GetById(string id)
        {
            var order = _orders.SingleOrDefault(o => Equals(o.Id, id));
            if(order == null)
            {
                throw new ArgumentException(string.Format("Order Id '{0}' is invalid", id));
            }
            return order;
        }

        Task<Order> IOrderService.CreateAsync(Order order)
        {
            _orders.Add(order);
            return Task.FromResult(order);
            throw new NotImplementedException();
        }

        Task<Order> IOrderService.GetOrderByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Order>> IOrderService.GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        Task<Order> IOrderService.StartAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Start();
            return Task.FromResult(order);
        }
    }

    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> StartAsync(string orderId);
    }
}
