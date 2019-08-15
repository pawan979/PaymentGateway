using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class Transaction
    {   
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public double Amount { get; set; }
    }
}
