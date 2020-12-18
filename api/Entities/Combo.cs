namespace api.Entities
{
    public class Combo : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DiscountPercent { get; set; }
        public double Price { get; set; }
        public double PriceForSale { get; set; }

    }
}