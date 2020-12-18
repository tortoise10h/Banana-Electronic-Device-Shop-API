using api.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Description { get; set; }
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<GoodsDeliveryNote> GoodsDeliveryNotes { get; set; }
    }
}
