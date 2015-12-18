using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchStore.BusinessLogic.Interfaces;
using WatchStore.DataAccess.Entities;
using WatchStore.DataAccess.Interfaces;

namespace WatchStore.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderWatchRepository _orderWatchRepository;
        private readonly IWatchService _watchService;

        public OrderService(IOrderRepository orderRepository, IOrderWatchRepository orderWatchRepository, IWatchService watchService)
        {
            _orderRepository = orderRepository;
            _orderWatchRepository = orderWatchRepository;
            _watchService = watchService;
        }

        public Order GetById(int? id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
            
        }

        public void MakeOrder(Order order)
        {
            order.Date = DateTime.Now;
            _orderRepository.MakeOrder(order);
        }

        public void EditOrder(Order order)
        {
            _orderRepository.EditOrder(order);
        }

        public void RemoveOrder(int? id)
        {
            _orderRepository.RemoveOrder(id);
        }

        public void MakeDependency(Order order, Watch watch, int quantity)
        {
            _orderWatchRepository.MakeDependency(order, watch, quantity);
        }

        public void RemoveDependency(Order order, Watch watch, int quantity)
        {
            _orderWatchRepository.RemoveDependency(order, watch, quantity);
        }
    }
}
