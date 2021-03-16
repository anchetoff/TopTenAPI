using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopTenAPI.Implementation;
using TopTenAPI.Interfaces;

using Autofac;

namespace TopTenAPI.ApiProperties
{
    public class ServiceModules: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new HttpContextWrapper(HttpContext.Current)).As<HttpContextBase>().InstancePerRequest();

            builder.RegisterType<ResultsService>().As<IResults>();
        }
    }
}