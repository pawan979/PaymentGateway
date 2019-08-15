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
        public const string DateValidationError = "An error occured while validating the date.  Please refer to stacktrace below {0}";

        public const string InvalidCardNumber = "The card number is invalid.";
        public const string TransactionNotFound = "The transaction could not be retrieved";

        public const string ErrorWhenRetrievingTransaction = "An error occured while retrieving the transaction.  Please refer to below {0}";
        public const string ErrorWhenSavingTransaction = "An error occured while saving the transaction.  Please refer to stacktrace below {0}";


    }
}
