using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EShop.MVC.ErrorPages
{
    public partial class Oops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int statuscodeint = 0;
            string statuscode = this.Request.QueryString["statuscode"];
            if (!int.TryParse(statuscode, out statuscodeint))
                statuscodeint = 500;
            
            string description = HttpWorkerRequest.GetStatusDescription(statuscodeint);

            this.statusanddescription.Text = statuscodeint.ToString() + " " + description;



            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                if (ex.GetBaseException() != null)
                {
                    ex = ex.GetBaseException();
                    //Guardar el error en un log
                }
            }
            
        }
    }
}