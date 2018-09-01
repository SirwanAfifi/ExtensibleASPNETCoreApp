using MvcCoreSample.DomainClasses;
using MvcCoreSample.Services.Contracts;

namespace MvcCoreSample.Providers
{
    public class Mailer : IMailer
    {
        public void SendInvoiceEmail(OrderData orderData)
        {
            throw new System.NotImplementedException();
        }

        public void SendRejectionEmail(OrderData orderData)
        {
            throw new System.NotImplementedException();
        }
    }
}
