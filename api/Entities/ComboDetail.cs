namespace api.Entities
{
    public class ComboDetail : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ComboId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Combo Combo { get; set; }
    }
}