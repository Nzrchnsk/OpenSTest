using System;
using Core.Interfaces;

namespace Core.Entities
{
    /// <summary>
    /// Класс для хранения заказов в базе. 
    /// </summary>
    public class Order : BaseEntity, IAggregateRoot
    {
        public int Id { get; set; }
        
        /// <summary>
        /// talabat, zomato, uber
        /// </summary>
        public string SystemType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Исходный  JSON заказа который прилетает в апи
        /// </summary>
        public string SourceOrder { get; set; }
        
        /// <summary>
        /// Конвертированный приложением JSON заказа прилетевшего в апи
        /// </summary>
        public string ConvertedOrder { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}