using EShop.CORE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Nombre")] 
        public string Name { get; set; }

        /// <summary>
        /// precio del producto
        /// </summary>
        [Display(Name = "Precio")] 
        public decimal Price { get; set; }

        /// <summary>
        /// stock del producto
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Lista de imagenes del producto
        /// </summary>
        [Display(Name = "Imágenes")]
        public Image Image { get; set; }
    
}
    }
