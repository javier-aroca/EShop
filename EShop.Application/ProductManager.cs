using EShop.CORE;
using EShop.CORE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DAL;

namespace EShop.Application
{
    public class ProductManager : GenericManager<Product>, IProductManager
    {

        IApplicationDbContext context;
        /// <summary>
        /// constructor del mananager de productos 
        /// </summary>
        /// <param name="context">contexto de datos</param>
        public ProductManager(IApplicationDbContext context) : base(context)
        {
            this.context = context;         
        }






    }
}
