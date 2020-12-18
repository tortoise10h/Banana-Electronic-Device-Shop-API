using api.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<GoodsReceivingDetail> GoodsReceivingDetails { get; set; }
        public ICollection<GoodsDeliveryDetail> GoodsDeliveryDetails { get; set; }
        public ICollection<QuantityLog> QuantityLogs { get; set; }
    }
}
