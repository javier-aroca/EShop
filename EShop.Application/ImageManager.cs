using EShop.CORE;
using EShop.CORE.Contracts;
using EShop.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application
{
    public class ImageManager : GenericManager<Image>, IImageManager
    {
        IApplicationDbContext context;

        /// <summary>
        /// contructor del manager de imagenes
        /// </summary>
        /// <param name="context"></param>
        public ImageManager(IApplicationDbContext context) : base(context)
        {
            this.context = context;
        }


    }
}
