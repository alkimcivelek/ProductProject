using Ninject.Modules;
using ProductProject.BusinessLogicLayer.Abstract;
using ProductProject.BusinessLogicLayer.Concrete;
using ProductProject.DataAccessLayer.Abstract;
using ProductProject.DataAccessLayer.Concrete.AdoNet;
using ProductProject.DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductProject.BusinessLogicLayer.CrossCuttingConcerns.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<AdoProductDal>().InSingletonScope();
        }
    }
}
