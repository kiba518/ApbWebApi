using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using SdudentApi.Filters;
using SdudentApi.Services;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SdudentApi
{
    [DependsOn(typeof(Abp.WebApi.AbpWebApiModule))]
    public class SdudentApiServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true;
            var cors = new EnableCorsAttribute("*", "*", "*");
            GlobalConfiguration.Configuration.EnableCors(cors);
        }
        public override void Initialize()
        {
            //按照约定，ABP自动注册所有 Repositories， Domain Services， Application Services， MVC 控制器和Web API控制器
            //ABP按照约定注册程序集，下面代码将告诉ABP要注册当前程序集。
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //动态ApiController创建需要在将当前程序集注册进ABP后，才可以调用
            //WebApi访问路径默认前缀api/services，Sdudent是我们追加的前缀，可以自定义，例如Sdudent/Task
            //外放成ApiController的服务需要继承ABP的IApplicationService接口，需要准守命名约定，这样才能被搜索到（服务命名约定：服务名+AppService，例如SearchSdudentAppService） 
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            .ForAll<IApplicationService>(Assembly.GetAssembly(typeof(SdudentApiServiceModule)), "Sdudent").Build();
            //https://localhost:44337/api/services/Sdudent/SearchSdudent/GetSdudent
        }
        public override void PostInitialize()
        {
            GlobalConfiguration.Configuration.Filters.Add(new ExceptionFilter());
        } 
        public override void Shutdown()
        {   
        }

        public string GetSdudent()
        {
            SearchSdudentAppService sss = new SearchSdudentAppService();
            return sss.GetSdudent();
        }
    }
}
