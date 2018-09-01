using MvcCoreSample.DomainClasses;

namespace MvcCoreSample.Services.Contracts
{
    public interface ICommerceEngine
    {
        void ProcessOrder(OrderData orderData);
    }
}