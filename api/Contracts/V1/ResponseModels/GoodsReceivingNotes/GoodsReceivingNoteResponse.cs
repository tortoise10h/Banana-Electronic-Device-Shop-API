using api.Common.Enums;
using api.Contracts.V1.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Contracts.V1.ResponseModels.GoodsReceivingNotes
{
    public class GoodsReceivingNoteResponse
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public double TotalPrice { get; set; }
        public List<GoodsReceivingDetailResponse> GoodsReceivingDetails { get; set; }
    }
}
