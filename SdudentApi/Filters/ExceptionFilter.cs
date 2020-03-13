using Abp.Dependency;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace SdudentApi.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionFilter : IExceptionFilter, ITransientDependency
    {
        public bool AllowMultiple => true; 
        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            await Task.Run(()=>
            {

                if (actionExecutedContext == null)
                {

                    return;
                }
                if (actionExecutedContext.Exception == null)
                {
                    return;
                }
                //记录actionExecutedContext.Exception
            }); 
        } 
    }
}