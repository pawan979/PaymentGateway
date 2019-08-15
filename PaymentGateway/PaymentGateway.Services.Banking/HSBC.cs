using PaymentGateway.Domain.Entities;
using PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PaymentGateway.Services.Bank
{
    public class HSBC : IBank
    {
        private readonly ILogger _Log;

        public HSBC(ILogger log)
        {
            _Log = log;
        }
        
        public BankResponse ProcessPayment(IncomingTransaction transaction)
        {
            BankResponse response = null;
            int num = 0;
            try
            {
                var newDate = Convert.ToDateTime("01/" + transaction.ExpiryDate);

                if (Common.Validation.IsCardExpired(_Log, newDate))
                {
                    //Call Bank API, for this POC, I mocked the response to be either pass or fail
                    num = new Random().Next();
                    if (num % 2 == 0)
                    {
                        response = new BankResponse() { TransactionId = Guid.NewGuid(), Status = 200 };
                    }
                    else
                    {
                        response = new BankResponse() { TransactionId = Guid.NewGuid(), Status = 400 };
                    }
                }
                else
                {
                    response = new BankResponse() { TransactionId = Guid.NewGuid(), Status = 422 };
                }

            }
            catch (Exception ex)
            {
                _Log.LogError(ex.Message);
            }

            return response;
        }
        
    }
}
