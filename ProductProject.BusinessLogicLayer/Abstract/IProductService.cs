using ProductProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProductProject.BusinessLogicLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product Get(Expression<Func<Product, bool>> filter);
    }

}
