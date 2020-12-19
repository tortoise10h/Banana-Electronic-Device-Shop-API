using api.CQRS.GoodsReceivingNotes.Commands.CreateGoodsReceivingDetails;
using api.Entities;
using AutoMapper;

namespace api.MapperProfiles
{
    public class DtoAndEntitiesProfile : Profile
    {
        public DtoAndEntitiesProfile()
        {
            /** ProductInGoodsReceivingNote - GoodsReceivingDetail */
            CreateMap<ProductInGoodsReceivingDetails, GoodsReceivingDetail>();
            CreateMap<GoodsReceivingDetail, ProductInGoodsReceivingDetails>();
        }
    }
}
