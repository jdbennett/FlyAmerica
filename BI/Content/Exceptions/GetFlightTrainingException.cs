using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDB.BI.Content.Exceptions
{
    public class GetFlightTrainingException : Exception 
    {
        public GetFlightTrainingException(string message, Exception ex)
            :base(message, ex)
        {

        }
    }
}
