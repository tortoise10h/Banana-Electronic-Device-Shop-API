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
        public string ExceptionReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public String LastModifiedBy { get; set; }
        public double TotalPrice { get; set; }

        public UserResponse User { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; }
        public List<GoodsDeliveryNoteResponse> GoodsDeliveryNotes { get; set; }
    }
}
