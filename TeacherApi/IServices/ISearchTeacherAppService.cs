using Abp.Application.Services;
using System.Web.Http;

namespace TeacherApi.Services
{
    public interface ISearchTeacherAppService : IApplicationService
    {
        [HttpGet]
        string GetTeacher();
         
    }
}