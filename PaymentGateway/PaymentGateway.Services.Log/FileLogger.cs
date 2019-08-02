using PaymentGateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace PaymentGateway.Services
{
    public class FileLogger : ILogger
    {
        public void LogError(string message)
        {
            string filePath = "C:\\Logs\\PaymentGateway";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (StreamWriter sw = File.AppendText(string.Format(@"{0}\LogError.txt", filePath)))
            {
                sw.WriteLine(string.Format("{0} - {1}", DateTime.Now, message));
            }
        }
    }
}
