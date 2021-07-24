namespace EShop.CORE
{
    public class Image
    {

        /// <summary>
        /// identificador de la foto del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ruta de la foto del producto 
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// orden de la foto del producto
        /// </summary>
        public int Order { get; set; }
    }
}