using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class TransactionSummary
    {
        public double Amount { get; set; }
        public string TransactionId { get; set; }
        public CardDetails Transaction { get; set; }
        public int Status { get; set; }
    }
}
