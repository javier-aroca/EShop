using EShop.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.MVC.Models
{
    public class OrderViewModel
    {
        /// <summary>
        /// identificador del pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// usuario que ha creado el pedido
        /// </summary>
        public String User { get; set; }

        /// <summary>
        /// identificador del usuario que realiza el pedido; tiene que existir como usuario
        /// </summary>

        public string UserId { get; set; }

        /// <summary>
        /// fecha de creacion del pedido
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// status del pedido (enum)
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// dirección de entrega del pedido
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// collección de lineas de pedido
        /// </summary>
        public List<OrderLine> OrderLines { get; set; }
    }
}