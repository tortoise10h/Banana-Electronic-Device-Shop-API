using api.Contracts.V1.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Contracts.V1.ResponseModels.GoodsDeliveryNotes
{
    public class GoodsDeliveryDetailResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int GoodsDeliveryNoteId { get; set; }
        public double Quantity { get; set; }
        public double QuantityReturned { get; set; }
        public double SinglePrice { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }

        public ProductResponse Product { get; set; }
    }
}
