using ProductProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.DataAccessLayer.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
