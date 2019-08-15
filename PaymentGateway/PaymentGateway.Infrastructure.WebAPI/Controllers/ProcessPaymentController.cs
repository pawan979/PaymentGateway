using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Services.Interfaces;
using PaymentGateway.Services.Log;
using System;

namespace PaymentGateway.Infrastructure.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProcessPaymentController : ControllerBase
    {
        [HttpPost]
        public BankResponse Post([FromBody] IncomingTransaction transaction)
        {
            SystemLog log = new SystemLog();

            BankResponse response = null;

            try
            {
                IBank bank = Services.BankServices.BankServices.GetBank(transaction.CardNumber);
                
                response = bank.ProcessPayment(transaction);

                Services.Common.CommonMethods.SaveTransaction(log, transaction, response);

            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
            }

            return response;
        }
       
    }
}
