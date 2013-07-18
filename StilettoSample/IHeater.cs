namespace StilettoSample
{
    public interface IHeater
    {
        bool IsHot { get; }
        void On();
        void Off();
    }
}
