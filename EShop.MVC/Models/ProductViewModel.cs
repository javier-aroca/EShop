using EShop.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.MVC.Models
{
    public class ProductViewModel
    {

    
        /// <summary>
        /// id del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// texto del producto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// precio del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// stock del producto
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Lista de imagenes del producto
        /// </summary>
        public Image Image { get; set; }
    
}
    }
