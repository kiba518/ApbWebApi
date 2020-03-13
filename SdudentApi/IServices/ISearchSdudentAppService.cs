using Abp.Application.Services;
using System.Web.Http;

namespace SdudentApi.Services
{
    public interface ISearchSdudentAppService : IApplicationService
    {
        [HttpGet]
        string GetSdudent();
        [HttpGet]
        string ThrowEx();
    }
}