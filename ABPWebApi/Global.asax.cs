using Abp.Web;
using ABPWebApi;
using SdudentApi;
using System;
using System.Web;
using TeacherApi;

[assembly: PreApplicationStartMethod(typeof(PreStarter), "Start")]
namespace ABPWebApi
{
    public class WebApiApplication : Abp.Web.AbpWebApplication<TeacherApiServiceModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        { 
            base.Application_Start(sender, e);  
        } 
    }
    public static class PreStarter
    {
        public static void Start()
        {
            //WebApiApplication.AbpBootstrapper.PlugInSources.AddFolder(System.Web.Hosting.HostingEnvironment.MapPath("~/Bundles"));
            WebApiApplication.AbpBootstrapper.PlugInSources.AddToBuildManager();

        }
    }
}
 