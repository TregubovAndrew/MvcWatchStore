using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WatchStore.DataAccess.Entities;

namespace WatchStoreWeb.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        public ICollection<OrderWatch> OrderWatches { get; set; }

        public OrderModel()
        {
            OrderWatches = new List<OrderWatch>();
        }

        public static OrderModel ConvertToOrderModel(Order order)
        {
            if (order == null)
                return new OrderModel();

            return new OrderModel()
            {
                Id = order.Id,
                Sum = order.Sum,
                Date = order.Date,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PostalCode = order.PostalCode,
                Country = order.Country,
                City = order.City,
                Address = order.Address,
                Phone = order.Phone,
                OrderWatches = order.OrderWatches
                //Watches = order.Watches

            };
        }

        public static Order ConvertToOrder(OrderModel order)
        {
            if (order == null)
                return new Order();

            return new Order()
            {
                Id = order.Id,
                Sum = order.Sum,
                Date = order.Date,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PostalCode = order.PostalCode,
                Country = order.Country,
                City = order.City,
                Address = order.Address,
                Phone = order.Phone,
                OrderWatches = order.OrderWatches
                //Watches = order.Watches

            };
        }
    }
}