using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeacherApi.Services
{
    public class SearchTeacherAppService : ISearchTeacherAppService
    {  
        public string GetTeacher()
        {
            return "I am a Teacher";
        } 
       
    }
}