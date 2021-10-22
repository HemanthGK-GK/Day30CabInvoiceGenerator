using System;
using System.Collections.Generic;
using System.Text;

namespace UC3EnhancedInvoice
{
    class CustomException:Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_USERID,
            NULL_RIDER

        }
        ExceptionType type;
        public CustomException(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }

       
    }
}
