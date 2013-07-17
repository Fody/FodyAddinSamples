using System;

namespace StilettoSample
{
    public class ElectricHeater : IHeater
    {
        public bool IsHot { get; private set; }

        public void On()
        {
            Console.WriteLine("~~~~heating~~~~");
            IsHot = true;
        }

        public void Off()
        {
            IsHot = false;
        }
    }
}
