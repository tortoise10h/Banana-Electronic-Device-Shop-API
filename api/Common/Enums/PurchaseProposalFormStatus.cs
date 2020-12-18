using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Common.Enums
{
    public enum PurchaseProposalFormStatus
    {
        New = 1,
        Processing = 2,
        Done = 3,
        Cancelled = 4,
        ForceDone = 5
    }
}
