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
        public double QuantityNeed { get; set; }
        public double QuantitySold { get; set; }
        public double QuantityReturned { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public String LastModifiedBy { get; set; }
        public double SinglePrice { get; set; }
        public double TotalPrice { get; set; }

        public ProductResponse Product { get; set; }
    }
}
