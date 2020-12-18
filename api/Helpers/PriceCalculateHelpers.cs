using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public interface IPriceCalculateHelpers
    {
        double CalculateTotalPriceOfProduct(double quantity, double singlePrice);
    }

    public class PriceCalculateHelpers: IPriceCalculateHelpers
    {
        public double CalculateTotalPriceOfProduct(double quantity, double singlePrice)
        {
            return Math.Ceiling(singlePrice * quantity);
        }
    }
}
