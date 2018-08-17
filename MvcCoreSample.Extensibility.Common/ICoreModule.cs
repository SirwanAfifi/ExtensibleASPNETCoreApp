namespace MvcCoreSample.Extensibility.Common
{
    public interface ICoreModule
    {
        void Initialize(MvcCoreSampleModuleEvents moduleEvents);
    }
}