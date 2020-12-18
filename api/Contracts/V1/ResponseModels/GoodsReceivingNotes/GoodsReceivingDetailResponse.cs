using api.Contracts.V1.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Contracts.V1.ResponseModels.GoodsReceivingNotes
{
    public class GoodsReceivingDetailResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int GoodsReceivingNoteId { get; set; }
        public double Quantity { get; set; }
        public double SinglePurchasePrice { get; set; }
        public double TotalPrice { get; set; }
        public string Description { get; set; }

        public ProductResponse Product { get; set; }
    }
}
