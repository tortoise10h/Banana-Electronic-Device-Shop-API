using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public interface IProductsService
    {
        string GenerateProductSKU(string categoryName, int productId);
    }
    public class ProductsService : IProductsService
    {
        public string GenerateProductSKU(string categoryName, int productId)
        {
            int postFixNumLength = 5;
            string SKU = "SP-";

            /** Implement for the shortenest further of category name */
            SKU += DerivedFirstLetterOfEachWordInString(categoryName)
                    .ToUpper();
            SKU += "-";

            /** Implement the number part */
            for(int i = 0; i < (postFixNumLength - productId.ToString().Length); i++)
            {
                SKU += "0";
            }
            SKU += productId;

            return SKU;
        }


        public string DerivedFirstLetterOfEachWordInString(string str)
        {
            string result = "";
            string[] words = str.Split(" ");
            /** Make sure do not take any redundant space */
            words = words
                .Where(w => w.Equals(" ") == false)
                .ToArray();

            foreach(string w in words)
            {
                result += w[0];
            }

            return result;
        }
    }
}
