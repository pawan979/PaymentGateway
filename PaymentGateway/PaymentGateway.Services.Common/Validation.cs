using PaymentGateway.Services.Interfaces;
using System;

namespace PaymentGateway.Services.Common
{
    public static class Validation
    {
        public static bool IsCardExpired(ILogger log , DateTime date)
        {
            bool valid = false;
            try
            {
                 if(date != DateTime.MinValue)
                {
                    if(DateTime.Now <= date)
                    {
                        valid = true;
                    }
                    else
                    {
                        log.LogError(Constants.CardExipred);
                    }
                }
                else
                {
                    log.LogError(Constants.DateNotAvailable);
                    return valid;
                }
            }
            catch(Exception ex)
            {
                log.LogError(string.Format(Constants.DateValidationError, ex.StackTrace));
            }

            return valid;
        }
        
    }
}
