using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.MVC.Models
{
    public class OrderLineModel
    {
        /// <summary>
        /// identificador de la linea de pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// nombre del producto
        /// </summary>
        [Display(Name = "Producto")] 
        public string ProductName { get; set; }

        /// <summary>
        /// precio del producto
        /// </summary>
        [Display(Name = "Precio")] 
        public decimal Price { get; set; }

        /// <summary>
        /// cantidad del producto
        /// </summary>
        [Display(Name = "Cantidad")] 
        public int Quantity { get; set; }

        /// <summary>
        /// id de su orden de pedido
        /// </summary>
        public int OrderId { get; set; }


    }
}