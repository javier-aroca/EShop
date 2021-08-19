namespace EShop.CORE
{
    /// <summary>
    /// estados del pedido
    /// </summary>
    public enum OrderStatus : int
    {
        /// <summary>
        /// pedido pendiente no pagado
        /// </summary>
        Procesado = 0,
        /// <summary>
        /// pedido pagado pero no enviado
        /// </summary>
        Enviado = 1,
        /// <summary>
        /// pedido pagado y enviado
        /// </summary>
        Recibido = 2
    }
}