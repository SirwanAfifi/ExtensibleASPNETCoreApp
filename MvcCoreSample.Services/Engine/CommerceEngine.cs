using Microsoft.Extensions.Options;
using MvcCoreSample.DomainClasses;
using MvcCoreSample.Extensibility.Common;
using MvcCoreSample.Services.Contracts;
using System;

namespace MvcCoreSample.Services.Engine
{
    public class CommerceEngine : ICommerceEngine
    {
        private readonly AppSettings _appSettings;
        IPaymentProcessor _paymentProcessor;
        IMailer _mailer;

        public CommerceEngine(IOptions<AppSettings> appSettings)
        {
            if (_appSettings?.CommerceEngine != null)
            {
                _paymentProcessor = Activator.CreateInstance(Type.GetType(_appSettings.CommerceEngine.PaymentProcessor.Type)) as IPaymentProcessor;
                _mailer = Activator.CreateInstance(Type.GetType(_appSettings.CommerceEngine.Mailer.Type)) as IMailer;
            }
        }

        public void ProcessOrder(OrderData orderData)
        {
            Console.WriteLine("Order Processed!");
        }
    }
}
