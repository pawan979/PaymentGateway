using PaymentGateway.Services;
using PaymentGateway.Services.Common;
using System;
using Xunit;

namespace PaymentGateway.UnitTesting
{
    public class UnitTests
    {
        private FileLogger _log;
        public UnitTests()
        {
            _log = new FileLogger();
        }

        [Fact]
        public void MaskCardNumber()
        {
            string cardNumber = "1234567893694567";

            try
            {
                var expectedOutput = "1234-xxxx-xxxx-4567";
                var actualOutput = CommonMethods.MaskCardNumber(_log, cardNumber);
                Assert.Equal(expectedOutput, actualOutput);

            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }

        [Fact]
        public void RetrieveTransaction()
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }
    }
}
