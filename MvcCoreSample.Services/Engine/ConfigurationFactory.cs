using Microsoft.Extensions.Options;
using MvcCoreSample.DomainClasses.Contracts;
using MvcCoreSample.Extensibility.Common;
using MvcCoreSample.Services.Contracts;
using System;

namespace MvcCoreSample.Services.Engine
{
    public class ConfigurationFactory : IConfigurationFactory
    {
        private AppSettings _appSettings;
        IPaymentProcessor _paymentProcessor;
        IMailer _mailer;

        public ConfigurationFactory(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            var commerceEngineConfig = _appSettings.CommerceEngineConfig;

            if (commerceEngineConfig != null)
            {
                _paymentProcessor = Activator.CreateInstance(Type.GetType(commerceEngineConfig.PaymentProcessor.Type)) as IPaymentProcessor;
                _mailer = Activator.CreateInstance(Type.GetType(commerceEngineConfig.Mailer.Type)) as IMailer;
            }
        }

        public IPaymentProcessor GetPaymentProcessor()
        {
            return _paymentProcessor;
        }

        public IMailer GetMailer()
        {
            return _mailer;
        }
    }
}
