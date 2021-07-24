using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.CORE
{
    public class ShoppingCartLine
    {
        /// <summary>
        /// id de la linea del carrito
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// producto que incluye en el carrito
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// identificador del producto que se incluye en el carrito
        /// </summary>
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        /// <summary>
        /// cantidad de producto
        /// </summary>
        public int Quantity { get; set; }
    }
}