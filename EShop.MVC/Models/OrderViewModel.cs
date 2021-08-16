using EShop.CORE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Dirección")]
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// lista de lineas de pedido
        /// </summary>
        public virtual List<OrderLine> OrderLines { get; set; }
        
    }
}