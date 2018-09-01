namespace MvcCoreSample.Services.Contracts
{
    public interface IPaymentProcessor
    {
        bool ProcessCreditCard(string customerName, 
                               string creditCard, 
                               string expirationDate, 
                               double amount);
    }
}
