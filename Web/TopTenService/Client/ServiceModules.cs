
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using TopTenService.Client.Implementation;
using TopTenService.Client.Interface;


namespace TopTenAPI.ApiProperties
{
    public class ServiceModules: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new HttpContextWrapper(HttpContext.Current)).As<HttpContextBase>().InstancePerRequest();

            builder.RegisterType<TopTenClient>().As<IServiceClient>();
        }
    }
}