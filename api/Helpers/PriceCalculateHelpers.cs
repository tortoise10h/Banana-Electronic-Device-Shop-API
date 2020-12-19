using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public interface IPriceCalculateHelpers
    {
        double CalculateTotalPriceOfProduct(double quantity, double singlePrice);
        double CalculateDiscountPrice(
            double priceBeforeDiscount,
            double discountPercentage);
    }

    public class PriceCalculateHelpers : IPriceCalculateHelpers
    {
        public double CalculateTotalPriceOfProduct(double quantity, double singlePrice)
        {
            return Math.Ceiling(singlePrice * quantity);
        }

        public double CalculateDiscountPrice(
            double priceBeforeDiscount,
            double discountPercentage)
        {
            return Math.Floor((priceBeforeDiscount - (priceBeforeDiscount * discountPercentage) / 100));
        }
    }
}
