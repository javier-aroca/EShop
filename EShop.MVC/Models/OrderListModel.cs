using EShop.CORE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.MVC.Models
{
    public class OrderListModel
    {
        /// <summary>
        /// identificador del pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// usuario que ha creado el pedido
        /// </summary>
        [Display(Name = "Usuario")] 
        public String User { get; set; }

        /// <summary>
        /// identificador del usuario que realiza el pedido; tiene que existir como usuario
        /// </summary>
      
        public string UserId { get; set; }

        /// <summary>
        /// fecha de creacion del pedido
        /// </summary>
        [Display(Name = "Fecha")] 
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// status del pedido (enum)
        /// </summary>
        [Display(Name = "Estado")] 
        public OrderStatus Status { get; set; }

        /// <summary>
        /// dirección de entrega del pedido
        /// </summary>
        [Display(Name = "Dirección de envío")] 
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// collección de lineas de pedido
        /// </summary>
        public List<OrderLine> OrderLines { get; set; }
    }
}