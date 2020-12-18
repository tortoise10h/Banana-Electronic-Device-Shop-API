using api.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class GoodsDeliveryNote : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public double TotalPrice { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<GoodsDeliveryDetail> GoodsDeliveryDetails { get; set; }
        public Order Order { get; set; }
    }
}
