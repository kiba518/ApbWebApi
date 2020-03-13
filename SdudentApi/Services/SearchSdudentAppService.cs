using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SdudentApi.Services
{
    public class SearchSdudentAppService: ISearchSdudentAppService
    { 
        public string GetSdudent()
        {
            return "I am a Sdudent";
        }

        public string ThrowEx()
        {
            throw new NotImplementedException();
        }
    }
}