using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Common.Enums
{
    public enum GoodsDeliveryNoteStatus
    {
        New = 1,
        Pending = 2,
        Approved = 3,
        Done = 4,
        Cancelled = 5
    }
}
