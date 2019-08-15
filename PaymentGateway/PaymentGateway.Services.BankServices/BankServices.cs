using PaymentGateway.Domain.Entities;
using PaymentGateway.Services.Bank;
using PaymentGateway.Services.Interfaces;
using PaymentGateway.Services.Log;
using System;

namespace PaymentGateway.Services.BankServices
{
    public class BankServices
    {
        public BankResponse ProcessBankPayment(IBank bank, IncomingTransaction transaction)
        {
            BankResponse response;
            try
            {
                response = bank.ProcessPayment(transaction);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public static IBank GetBank(string cardNumber)
        {
            string bankCode = string.Empty;
            IBank bank = null;
            
            try
            {
                if (!string.IsNullOrEmpty(cardNumber))
                {
                    bankCode = cardNumber.Substring(0, 4);

                    switch (bankCode)
                    {
                        case "1234":
                            bank = new HSBC(new FileLogger());
                            break;

                        case "4567":
                            bank = new MCB(new EventViewerLogger());
                            break;

                        default:
                            bank = new StandardBank(new SystemLog());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bank;
        }
    }
}
