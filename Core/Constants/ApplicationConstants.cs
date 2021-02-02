using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Helpers.OrderConverters;

namespace Core.Constants
{
    public class ApplicationConstants
    {
        private static Dictionary<string, IOrderConverter> orderHandlersMap = new Dictionary<string, IOrderConverter>
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