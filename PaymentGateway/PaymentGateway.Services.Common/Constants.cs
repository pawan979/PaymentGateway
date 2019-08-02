using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Services.Common
{
    public static class Constants
    {

        public const string ApplicationName = "Payment Gateway";


        public const string CardExipred = "The card has Expired.  Please contact your Bank";
        public const string DateNotAvailable = "The card Expiry date could not be retrieved.";
        public const string DateValidationError = "An error occured while validating the date.  Please see stacktrace below {0}";


        public const string InvalidCardNumber = "The card number is invalid.";

    }
}
