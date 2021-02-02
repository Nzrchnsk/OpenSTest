using System;
using Core.Interfaces;
using JetBrains.Annotations;

namespace Core.Entities
{
    /// <summary>
    /// Класс для хранения заказов в базе. 
    /// </summary>
    public class Order : BaseEntity, IAggregateRoot
    {
        public Order()
        {
        }
        public Order(int id, string systemType, string sourceOrder, DateTime createdAt)
        {
            base.Id = id;
            SystemType = systemType;
            SourceOrder = sourceOrder;
            CreatedAt = createdAt;
        }
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
        [CanBeNull]
        public string ConvertedOrder { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}