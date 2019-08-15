using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class IncomingTransaction: Transaction
    {
        public string CCV { get; set; }
        public string ExpiryDate { get; set; }
    }
}
