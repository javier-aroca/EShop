using EShop.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DAL;
using EShop.CORE.Contracts;
using System.Net.Mail;
using System.Windows.Forms;

namespace EShop.Application
{
    /// <summary>
    /// manager de pedido
    /// </summary>
    public class OrderManager : GenericManager<Order>, IOrderManager
    {
        IApplicationDbContext context;
        /// <summary>
        /// constructor del manager de pedido
        /// </summary>
        /// <param name="context">contexto de datos</param>
        public OrderManager(IApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// retorna los pedidos de un usuario
        /// </summary>
        /// <param name="userId">usuario</param>
        /// <returns>todos los pedidos de un usuario</returns>
        public IQueryable<Order> GetByUserId(string userId)
        {
            try
            {
                var result = Context.Set<Order>().Include("OrderLines").Where(e => e.UserId == userId);

                return result;
            }
            catch(Exception e)
            {
                throw new Exception("Se ha producido un fallo al recuperar los pedidos del usuario especificado");
            }
        }

        /// <summary>
        /// obtiene un pedido con sus lineas de pedido
        /// </summary>
        /// <param name="id">id del pedido</param>
        /// <returns>pedido con sus lineas</returns>
        public Order GetByIdandOrderLines(int id)
        {
            return Context.Set<Order>().Include("OrderLines").Where(i => i.Id == id).FirstOrDefault();
            //TODO: comprobar como sacar todas las lineas de pedido de un pedido con el manager; FirstOrDefault solamente saca una, creo que es quitarlo y tener la lista
        }

        /// <summary>
        /// método que crea una orden de compra y borra las lineas del carrito
        /// </summary>
        /// <param name="userId">usuario logeado</param>
        public void Create(string userId, string deliveryAddress, string userName)
        {
            ShoppingCartLineManager shoppingCartLineManager = new ShoppingCartLineManager(context);
            

            Order newOrder = new Order()
            {
                UserId = userId,
                CreateDate = DateTime.Now,
                Status = OrderStatus.Procesado,
                DeliveryAddress = deliveryAddress,
                OrderLines = new List<OrderLine>()
            };

            //por cada linea del carrito creo una linea de pedido
            foreach (ShoppingCartLine shoppingCartLine in shoppingCartLineManager.GetByUserId(userId))
            {
                OrderLine line = new OrderLine()
                {
                    ProductName = shoppingCartLine.Product.Name,
                    Price = shoppingCartLine.Product.Price,
                    Quantity = shoppingCartLine.Quantity
                };
                

                newOrder.OrderLines.Add(line);
                Context.Set<ShoppingCartLine>().Remove(shoppingCartLine);
            }
            Context.Set<Order>().Add(newOrder);//añado

            try
            {
                context.SaveChanges();//guardo cambios
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un problema al acceder a la base de datos");
            }

            sendEmail(userName, newOrder);//envio un email de confirmacion 
        }


        /// <summary>
        /// envio un email con los datos del pedido realizado
        /// </summary>
        /// <param name="mailAddress"></param>
        /// <param name="order"></param>
        private void sendEmail(string mailAddress, Order order)
        {
            string to = mailAddress;//email del cliente
            string from = "admin@admin.com";//desde admin
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Información nuevo pedido";//tema
            message.Body = "Se ha registrado un nuevo pedido a tu nombre.\nLos productos incluidos son:" +
                            "\n" + String.Join("\n", order.OrderLines.Select(x => x.ProductName + ": " + x.Quantity));

            //NOTA: esta parte la dejo comentada ya que no hay un servidor de correo SMTP. 
            /*SmtpClient client = new SmtpClient(server);*/
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            /*client.UseDefaultCredentials = true;*/


            //en vez de email, envío un mensaje al usuario
            // inicializar las variables para el metodo MessageBox.Show
            string messageBox = "Compra realizada. Se ha enviado un email de confirmación";
            string caption = "Mensaje";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // mostrar el MessageBox.
            result = MessageBox.Show(messageBox, caption, buttons);


            try
            {
                /*client.Send(message);*/
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al enviar el email de confirmación",
                    ex.ToString());
            }

        }

        
    }
}