using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TracerOwnLogAdapter.Adapters
{
    public static class LogManagerAdapter
    {
        public static LoggerAdapter GetLogger(Type type)
        {
            return new LoggerAdapter(type);
        }
    }
}
