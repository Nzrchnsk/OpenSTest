using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Helpers
{
    public class OrderConverter
    {
        private static Dictionary<string, Func<Order, Order>> orderHandlersMap = new Dictionary<string,Func<Order, Order>>
        {
            {"talabat", order => { 
                order.Id = 0;
                return order;
            }},
            
        };
    }
}