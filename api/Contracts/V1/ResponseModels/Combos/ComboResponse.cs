using System;
using System.Collections.Generic;

namespace api.Contracts.V1.ResponseModels.Combos
{
    public class ComboResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DiscountPercent { get; set; }
        public double Price { get; set; }
        public double PriceForSale { get; set; }
        public DateTime CreateAt { get; set; }
        public List<ComboDetailResponse> ComboDetails { get; set; }
    }
}