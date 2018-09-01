using MvcCoreSample.Services.Contracts;
namespace MvcCoreSample.Providers
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public bool ProcessCreditCard(string customerName, string creditCard, string expirationDate, double amount)
        {
            System.Console.WriteLine("Credit card processed with Axme Payment Gateway");

            return true;
        }
    }
}
