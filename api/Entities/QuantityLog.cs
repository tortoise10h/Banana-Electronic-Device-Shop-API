namespace api.Entities
{
    public class QuantityLog : BaseEntity
    {
        public int Id { get; set; }
        public int InStock { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}