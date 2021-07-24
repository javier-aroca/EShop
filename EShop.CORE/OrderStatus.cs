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
        Pendiente = 0,
        /// <summary>
        /// pedido pagado pero no enviado
        /// </summary>
        Pagado = 1,
        /// <summary>
        /// pedido pagado y enviado
        /// </summary>
        Enviado = 2
    }
}