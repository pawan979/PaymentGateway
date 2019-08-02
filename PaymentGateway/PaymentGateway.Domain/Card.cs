using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class CardDetails
    {
        private string CCV { get; set; }
        private string ExpiryDate { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }

    }
}
