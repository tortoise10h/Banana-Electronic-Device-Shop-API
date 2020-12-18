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
        public int Quantity { get; set; }
        public double UniPrice { get; set; }
        public double TotalPrice { get; set; }
        public ProductResponse Product { get; set; }
    }
}
