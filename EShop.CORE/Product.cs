using System.Collections.Generic;

namespace EShop.CORE
{
    /// <summary>
    /// entidad de dominio de productos
    /// </summary>
    public class Product
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
        public float Price { get; set; }

        /// <summary>
        /// stock del producto
        /// </summary>
        public int Stock { get; set; }

    /// <summary>
    /// Lista de imagenes del producto
    /// </summary>
    public virtual List<Image> Images { get; set; }
    }
}
