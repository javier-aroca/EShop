using EShop.CORE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop.MVC.Models
{
    /// <summary>
    /// Clase para listar los productos del carrito del cliente
    /// </summary>
    public class ShoppingCartList
    {
        /// <summary>
        /// id de la linea del carrito
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Usuario que ha creado la incidencia
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Identificador del usuario que ha creado la incidencia
        /// </summary>
        [ForeignKey("User")]
        public string UserId { get; set; }

        /// <summary>
        /// producto que incluye en el carrito
        /// </summary>
        [Display(Name = "Producto")]
        public Product Product { get; set; }

        /// <summary>
        /// identificador del producto que se incluye en el carrito
        /// </summary>
/*        [ForeignKey("Product")]
        public int ProductId { get; set; }*/

        /// <summary>
        /// cantidad de producto
        /// </summary>
        [Display(Name = "Cantidad")] 
        public int Quantity { get; set; }
    }
}