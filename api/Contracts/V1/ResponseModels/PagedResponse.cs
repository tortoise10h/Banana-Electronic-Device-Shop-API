
using System.Collections.Generic;

namespace api.Contracts.V1.ResponseModels
{
    public class PagedResponse<T>
    {
        public PagedResponse()
        {
        }

        public PagedResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}