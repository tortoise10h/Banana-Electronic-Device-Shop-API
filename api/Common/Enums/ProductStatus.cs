using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Common.Enums
{
    public enum ProductStatus
    {
        Available = 1, // TODO: Can do everything with a product
        Unavailable = 2, // TODO: No edit
        Hided = 3, // TODO: Can't appear on front page
        Locked = 4 //TODO: Lock buy and sell
    }
}
