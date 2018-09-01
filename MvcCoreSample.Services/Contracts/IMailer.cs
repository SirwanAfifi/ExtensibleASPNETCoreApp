using MvcCoreSample.DomainClasses;

namespace MvcCoreSample.Services.Contracts
{
    public interface IMailer
    {
        void SendInvoiceEmail(OrderData orderData);
        void SendRejectionEmail(OrderData orderData);
    }
}
