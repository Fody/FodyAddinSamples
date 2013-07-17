using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StilettoSample
{
    public interface IHeater
    {
        bool IsHot { get; }
        void On();
        void Off();
    }
}
