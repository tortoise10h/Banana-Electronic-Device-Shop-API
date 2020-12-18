using api.Common.Enums;
using api.Contracts.V1.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Contracts.V1.ResponseModels.GoodsDeliveryNotes
{
    public class GoodsDeliveryNoteResponse
    {
        public int Id { get; set; }
        public GoodsDeliveryNoteStatus Status { get; set; }
        public string Description { get; set; }
        public string ExceptionReason { get; set; }
        public int OrderId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<GoodsDeliveryDetailResponse> GoodsDeliveryDetails { get; set; }
        public UserResponse User { get; set; }
    }
}
