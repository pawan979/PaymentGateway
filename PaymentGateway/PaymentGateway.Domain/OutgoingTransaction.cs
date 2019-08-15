using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class OutgoingTransaction : Transaction
    {
        public string TransactionId { get; set; }
        public int Status { get; set; }
        public DateTime DateTime { get; set; }

    }
}
