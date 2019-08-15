using Newtonsoft.Json;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace PaymentGateway.Services.Common
{
    public static class CommonMethods
    {
        public static void SaveTransaction(ILogger log, IncomingTransaction transaction, BankResponse response)
        {
            List<OutgoingTransaction> transactions = new List<OutgoingTransaction>();
            try
            {
                string filePath = @"C:\Transactions";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string file = string.Format("{0}\\{1}", filePath, "Transactions.json");

                if(File.Exists(file))
                {
                    var json = File.ReadAllText(file);
                    transactions = JsonConvert.DeserializeObject<List<OutgoingTransaction>>(json);
                }

                transactions.Add(new OutgoingTransaction() {Amount = transaction.Amount,
                                                            CardNumber = transaction.CardNumber,
                                                            CardType = transaction.CardType,
                                                            Status = response.Status,
                                                            DateTime = DateTime.Now,
                                                            TransactionId = response.TransactionId.ToString() });

                File.WriteAllText(file, JsonConvert.SerializeObject(transactions));
            }
            catch(Exception ex)
            {
                log.LogError(string.Format(Constants.ErrorWhenRetrievingTransaction, ex.StackTrace));

            }
                        
        }

        public static OutgoingTransaction GetTransaction(ILogger log, string transactionId)
        {
            List<OutgoingTransaction> transactions = new List<OutgoingTransaction>();

            OutgoingTransaction transaction = null;

            try
            {
                string filePath = @"C:\Transactions";

              
                string file = string.Format("{0}\\{1}", filePath, "Transactions.json");

                if (File.Exists(file))
                {
                    var json = File.ReadAllText(file);
                    transactions = JsonConvert.DeserializeObject<List<OutgoingTransaction>>(json);

                    transaction = transactions.Where(t => t.TransactionId == transactionId).First();

                    if(transaction != null)
                    {
                        transaction.CardNumber = MaskCardNumber(log, transaction.CardNumber);
                    }
                    else
                    {
                        log.LogError(Constants.TransactionNotFound);
                    }
                }
               
            }
            catch (Exception ex)
            {
                log.LogError(string.Format(Constants.ErrorWhenRetrievingTransaction, ex.StackTrace));
            }

            return transaction;
        }


        public static string MaskCardNumber(ILogger log, string cardNumber)
        {
            string maskedCardNumber = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(cardNumber))
                {
                    maskedCardNumber = string.Format("{0}-xxxx-xxxx-{1}", cardNumber.Substring(0, 4), cardNumber.Substring(cardNumber.Length - 4, 4));
                }
                else
                {
                    log.LogError(string.Format(Constants.InvalidCardNumber));
                }

            }
            catch (Exception ex)
            {
                log.LogError(string.Format(Constants.DateValidationError, ex.StackTrace));
            }

            return maskedCardNumber;
        }
    }
}
