using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using SdudentApi;
using Swashbuckle.Application;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
 

namespace TeacherApi
{
    [DependsOn(typeof(Abp.WebApi.AbpWebApiModule), typeof(SdudentApiServiceModule))]
    public class TeacherApiServiceModule : AbpModule
    {
        private readonly SdudentApiServiceModule _SdudentApiServiceModule;
        public TeacherApiServiceModule(SdudentApiServiceModule sdudentApiServiceModule)
        {
            _SdudentApiServiceModule = sdudentApiServiceModule;
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;
            Configuration.Modules.AbpWebCommon().SendAllExceptionsToClients = true; 
        }
        public override void Initialize()
        { 
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly()); 
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
            .ForAll<IApplicationService>(Assembly.GetAssembly(typeof(TeacherApiServiceModule)), "Teacher").Build();
            ConfigureSwaggerUi();
        }
        public override void PostInitialize()
        {
            var ret =_SdudentApiServiceModule.GetSdudent();
            Console.WriteLine(ret); 
          
        } 
        public override void Shutdown()
        {   
        }
        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "文档");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi();
        }
    }
}
