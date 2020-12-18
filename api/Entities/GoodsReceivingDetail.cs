using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class GoodsReceivingDetail : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int GoodsReceivingNoteId { get; set; }
        public int Quantity { get; set; }
        public double UniPrice { get; set; }
        public double TotalPrice { get; set; }

        public Product Product { get; set; }
        public GoodsReceivingNote GoodsReceivingNote { get; set; }
    }
}
