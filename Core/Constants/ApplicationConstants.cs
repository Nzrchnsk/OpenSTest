using System.Collections.Generic;
using Core.Helpers.OrderConverters;

namespace Core.Constants
{
    public class ApplicationConstants
    {
        public static Dictionary<string, IOrderConverter> OrderHandlers = new Dictionary<string, IOrderConverter>
        {
            {
                "talabat", new TalabatConverter()
            },
            {
                "zomato", new ZomatoConverter()
            },
            {
                "uber", new UberConverter()
            },
        };
    }
}