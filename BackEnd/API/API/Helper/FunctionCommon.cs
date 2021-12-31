using System;

namespace API.Helper
{
    public  class FunctionCommon
    {
        public static DateTime ResetTimeToStartOfDay(DateTime dateTime)
        {
            return dateTime.Date;
        }
    }
}
