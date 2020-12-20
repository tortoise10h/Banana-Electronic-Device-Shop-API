using api.Common.Enums;
using api.Contracts.V1.ResponseModels.GoodsDeliveryNotes;
using api.Contracts.V1.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Contracts.V1.ResponseModels.Orders
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Description { get; set; }
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
    }
}
