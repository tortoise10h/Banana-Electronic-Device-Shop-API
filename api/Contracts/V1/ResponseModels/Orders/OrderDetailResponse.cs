using api.Contracts.V1.ResponseModels.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace api.Contracts.V1.ResponseModels.Orders
{
    public class OrderDetailResponse
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int ComboId { get; set; }
        public ProductResponse Product { get; set; }
    }
}
