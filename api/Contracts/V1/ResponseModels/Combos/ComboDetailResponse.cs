using api.Contracts.V1.ResponseModels.Products;

namespace api.Contracts.V1.ResponseModels.Combos
{
    public class ComboDetailResponse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ComboId { get; set; }
        public int Quantity { get; set; }

        public ProductResponse Product { get; set; }
    }
}