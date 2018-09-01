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
        private AppSettings _appSettings;

        IPaymentProcessor _paymentProcessor;
        IMailer _mailer;

        public CommerceEngine(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            var commerceEngineConfig = _appSettings.CommerceEngineConfig;

            if (commerceEngineConfig != null)
            {
               _paymentProcessor = Activator.CreateInstance(Type.GetType(commerceEngineConfig.PaymentProcessor.Type)) as IPaymentProcessor;
               _mailer = Activator.CreateInstance(Type.GetType(commerceEngineConfig.Mailer.Type)) as IMailer;
            }
        }

        public void ProcessOrder(OrderData orderData)
        {
            _paymentProcessor.ProcessCreditCard(orderData.CustomerEmail, orderData.CreditCard, string.Empty, 100000);
            Console.WriteLine("Order Processed!");
            _mailer.SendInvoiceEmail(orderData);
        }
    }
}
