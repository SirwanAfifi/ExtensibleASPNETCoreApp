namespace MvcCoreSample.DomainClasses.Contracts
{
    public interface ICommerceEngine
    {
        void ProcessOrder(OrderData orderData);
    }
}