using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Services;
using PaymentGateway.Services.Common;
using System;

namespace PaymentGateway.UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void MaskCardNumber()
        {
            FileLogger log = new FileLogger();

            string cardNumber = "1234-5678-9123-4567";

            try
            {
                var maskedCardNumber = CommonMethods.MaskCardNumber(log,cardNumber);
                Assert.AreEqual(maskedCardNumber, "1234-xxxx-xxxx-4567");

            }
            catch(Exception ex)
            {
                log.LogError(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }

        [TestMethod]
        public void RetrieveTransaction()
        {
            FileLogger log = new FileLogger();
            try
            {
                string transactionId = "fdfa2aae-3ba1-436d-8c91-e93e2026009a";

                var expectedResult = new TransactionSummary() {Status= 567, TransactionId = "fdfa2aae-3ba1-436d-8c91-e93e2026009a", Amount = 10.5, Transaction = new CardDetails() { CardNumber = CommonMethods.MaskCardNumber(log, "6549-8732-1963-8527"), CardType = "Visa" } };

                var actualResult =  Services.DataService.DataRetrieval.RetrieveTransaction(log, transactionId);

                Assert.AreEqual<TransactionSummary>(actualResult, expectedResult);

            }
            catch (Exception ex)
            {
                log.LogError(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }
    }
}
