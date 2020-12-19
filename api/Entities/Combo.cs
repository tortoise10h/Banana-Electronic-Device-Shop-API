using System.Collections.Generic;

namespace api.Entities
{
    public class Combo : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DiscountPercentage { get; set; }
        public double Price { get; set; }
        public double PriceForSale { get; set; }

        public ICollection<ComboDetail> ComboDetails { get; set; }
    }
}