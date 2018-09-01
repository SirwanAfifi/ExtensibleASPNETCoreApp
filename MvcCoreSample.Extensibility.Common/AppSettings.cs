namespace MvcCoreSample.Extensibility.Common
{
    public class AppSettings
    {
        public ExtensibilityModulesConfig[] ExtensibilityModules { get; set; }
        public CommerceEngineConfig CommerceEngineConfig { get; set; }
    }

    public class CommerceEngineBase
    {
        public string Type { get; set; }
        public string Name { get; set; }
    }

    public class CommerceEngineConfig
    {
        public PaymentProcessor PaymentProcessor { get; set; }
        public Mailer Mailer { get; set; }
    }

    public class PaymentProcessor : CommerceEngineBase
    {

    }

    public class Mailer : CommerceEngineBase
    {
        public string FromAddress { get; set; }
        public string SmtpServer { get; set; }
    }
}