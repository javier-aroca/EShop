namespace EShop.CORE
{
    /// <summary>
    /// entidad de dominio de lineas de pedido 
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// id de la linea de pedido
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// nombre del producto
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// precio del producto para ese pedido
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// cantidad de producto
        /// </summary>
        public int Quantity { get; set; }

    }
}
