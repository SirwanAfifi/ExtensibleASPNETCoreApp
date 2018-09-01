using MvcCoreSample.DomainClasses.Contracts;
using MvcCoreSample.Services.Contracts;

namespace MvcCoreSample.Services.Engine
{
    public interface IConfigurationFactory
    {
        IMailer GetMailer();
        IPaymentProcessor GetPaymentProcessor();
    }
}