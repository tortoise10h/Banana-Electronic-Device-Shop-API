using System;

namespace api.Contracts.V1.ResponseModels.Products
{
    public class QuantityLogStatisticResponse
    {
        public int Id { get; set; }
        public int InStock { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductResponse Product { get; set; }
    }
}