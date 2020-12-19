using api.CQRS.Categories.Commands.CreateCategories;
using api.CQRS.Categories.Commands.UpdateCategories;
using api.CQRS.Combos.Commands.CreateComboDetails;
using api.CQRS.Combos.Commands.CreateCombos;
using api.CQRS.Combos.Commands.UpdateComboDetails;
using api.CQRS.Combos.Commands.UpdateCombos;
using api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingDetails;
using api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingNotes;
using api.CQRS.GoodsReceivingNotes.Commands.DeleteGoodsReceivingNotes;
using api.CQRS.Orders.Commands.CreateOrders;
using api.CQRS.Orders.Commands.UpdateOrders;
using api.CQRS.Products.Commands.CreateProducts;
using api.CQRS.Products.Commands.UpdateProducts;
using api.Entities;
using AutoMapper;

namespace api.MapperProfiles
{
    public class CommandModelToEntityProfile : Profile
    {
        public CommandModelToEntityProfile()
        {
            /** Category */
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            /** GoodsReceivingNote */
            CreateMap<CreateGoodsReceivingNotesCommand, GoodsReceivingNote>();
            CreateMap<DeleteGoodsReceivingNotesCommand, GoodsReceivingNote>();
            CreateMap<CreateGoodsReceivingDetailsCommand, GoodsReceivingDetail>();

            /** Product */
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            /** Order */
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<UpdateOrderCommand, Order>();

            /** Combo */
            CreateMap<CreateComboCommand, Combo>();
            CreateMap<UpdateComboCommand, Combo>();

            /** ComboDetail */
            CreateMap<CreateComboDetailCommand, ComboDetail>();
            CreateMap<UpdateComboDetailCommand, ComboDetail>();
        }
    }
}
