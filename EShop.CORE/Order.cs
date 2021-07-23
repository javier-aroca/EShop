using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.CORE
{
    /// <summary>
    /// entidad de dominio de pedidos
    /// </summary>
    public class Order
    {
        /// <summary>
        /// identificador del pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// usuario que ha creado el pedido
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// identificador del usuario que realiza el pedido
        /// </summary>
        [ForeignKey("User")]
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
        public virtual List<OrderLine> OrderLines { get; set; }
    }

}
