using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class GoodsDeliveryDetail : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int GoodsDeliveryNoteId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }

        public Product Product { get; set; }
        public GoodsDeliveryNote GoodsDeliveryNote { get; set; }
    }
}
