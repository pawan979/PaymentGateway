﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class BankResponse
    {
        public Guid TransactionId { get; set; }
        public int Status { get; set; }
    }
}
