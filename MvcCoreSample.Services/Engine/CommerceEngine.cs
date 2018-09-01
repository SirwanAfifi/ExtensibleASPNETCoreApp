using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MvcCoreSample.DomainClasses;
using MvcCoreSample.DomainClasses.Contracts;
using MvcCoreSample.Extensibility.Common;
using MvcCoreSample.Services.Contracts;
using System;

namespace MvcCoreSample.Services.Engine
{
    public class CommerceEngine : ICommerceEngine
    {
        private IPaymentProcessor _paymentProcessor;
        private IMailer _mailer;

        public CommerceEngine(IConfigurationFactory configurationFactory)
        {
            _paymentProcessor = configurationFactory.GetPaymentProcessor();
            _mailer = configurationFactory.GetMailer();
        }

        public void ProcessOrder(OrderData orderData)
        {
            _paymentProcessor.ProcessCreditCard(orderData.CustomerEmail, orderData.CreditCard, string.Empty, 100000);
            Console.WriteLine("Order Processed!");
            _mailer.SendInvoiceEmail(orderData);
        }
    }
}
