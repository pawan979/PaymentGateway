using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Services.Interfaces
{
    public interface ILogger
    {
        void LogError(string Message);
    }
}
