using ProductProject.DataAccessLayer.Abstract;
using ProductProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.DataAccessLayer.Concrete.EntityFramework
{
    public class EFProductDal : EFRepositoryBase<Product, ProductProjectContext>, IProductDal
    {
    }

}
