using EShop.CORE;
using EShop.CORE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application
{
    public class ProductManager : GenericManager<Product>, IProductManager
    {
        /// <summary>
        /// constructor del mananager de productos 
        /// </summary>
        /// <param name="context">contexto de datos</param>
        public ProductManager(IApplicationDbContext context) : base(context)
        {
                  
        }




    }
}
