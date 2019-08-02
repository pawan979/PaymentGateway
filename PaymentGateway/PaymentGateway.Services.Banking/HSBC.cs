using PaymentGateway.Domain.Entities;
using PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace PaymentGateway.Services.Bank
{
    public class HSBC : IBank
    {
        private readonly ILogger _Log;

        public HSBC(ILogger log)
        {
            _Log = log;
        }
        
        public BankResponse ProcessPayment(CardDetails transaction)
        {
            BankResponse response = null;

            try
            { 

                response = new BankResponse() { TransactionId = Guid.NewGuid(),Status= true };
                //Save transaction and transaction Id.

            }
            catch (Exception ex)
            {
                _Log.LogError(ex.Message);
            }
            return response;
        }
        
    }
}
