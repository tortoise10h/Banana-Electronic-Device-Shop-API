using AutoMapper;
using api.Contracts.V1.ResponseModels.User;
using api.Entities;
using api.Contracts.V1.ResponseModels.Products;
using api.Contracts.V1.ResponseModels.GoodsReceivingNotes;
using api.Contracts.V1.ResponseModels.Orders;
using api.Contracts.V1.ResponseModels.GoodsDeliveryNotes;
using api.Contracts.V1.ResponseModels.Categories;
using api.Contracts.V1.ResponseModels.Combos;

namespace api.MapperProfiles
{
    public class EntityToResponseProfile : Profile
    {
        public EntityToResponseProfile()
        {
            CreateMap<ApplicationUser, UserResponse>();

            CreateMap<Product, ProductResponse>();

            CreateMap<Category, CategoryResponse>();

            CreateMap<GoodsReceivingNote, GoodsReceivingNoteResponse>();

            CreateMap<GoodsReceivingDetail, GoodsReceivingDetailResponse>();

            CreateMap<Order, OrderResponse>();

            CreateMap<OrderDetail, OrderDetailResponse>();

            CreateMap<GoodsDeliveryNote, GoodsDeliveryNoteResponse>();

            CreateMap<GoodsDeliveryDetail, GoodsDeliveryDetailResponse>();

            CreateMap<Combo, ComboResponse>();

            CreateMap<ComboDetail, ComboDetailResponse>();
        }
    }
}