using PaymentGateway.Domain.Entities;
using PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Services.Bank
{
    public class MCB : IBank
    {
        private readonly ILogger _Log;

        public MCB(ILogger log)
        {
            _Log = log;
        }

        public BankResponse ProcessPayment(CardDetails transaction)
        {
            BankResponse response = null;

            try
            {
                response = new BankResponse() { TransactionId = Guid.NewGuid(), Status = true };
            }
            catch (Exception ex)
            {
                _Log.LogError(ex.Message);
            }
            return response;
        }

    }
}
