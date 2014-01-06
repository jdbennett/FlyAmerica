using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.Content.Exceptions
{
    public class GetHomePageException : Exception
    {
        public GetHomePageException(string message, Exception ex)
            :base(message,ex)
        {
            
        }


    }
}
