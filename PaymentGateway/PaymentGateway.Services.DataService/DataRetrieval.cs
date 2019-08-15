using PaymentGateway.Domain.Entities;
using PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentGateway.Services.DataService
{
    public static class DataRetrieval
    {
        public static OutgoingTransaction RetrieveTransaction(ILogger log, string transactionId)
        {
            OutgoingTransaction response = null;

            try
            {
                response = Services.Common.CommonMethods.GetTransaction(log, transactionId);
            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }
            return response;
        }
    }
}
