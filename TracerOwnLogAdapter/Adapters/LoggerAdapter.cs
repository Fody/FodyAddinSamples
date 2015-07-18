using System;
using System.Collections.Generic;
using System.Text;

namespace TracerOwnLogAdapter.Adapters
{
    //here you should implement supporting methods for trace enter and leave plus all your static log methods counterpart
    public class LoggerAdapter
    {
        Type type;

        public LoggerAdapter(Type type)
        {
            this.type = type;
        }


        public void TraceEnter(string methodInfo, string[] paramNames, object[] paramValues)
        {
            //do the actual logging
            DoLog(string.Format("Entered into {0} {1} ({2})", type.FullName, methodInfo, BuildParameterInfo(paramNames, paramValues)));
        }

        public void TraceLeave(string methodInfo, long numberOfTicks, string[] paramNames, object[] paramValues)
        {
            //do the actual logging
            DoLog(string.Format("Returned from {0} {1} ({2})", type.FullName, methodInfo, BuildParameterInfo(paramNames, paramValues)));
        }

        public void MyLogSomethingImportant(string methodInfo, int importantValue, string message)
        {
            DoLog(string.Format("Returned from {0} {1} (Msg={2}, ImportantValue is {3})", type.FullName, methodInfo, message, importantValue));
        }

        string BuildParameterInfo(string[] paramNames, object[] paramValues)
        {
            if (paramNames == null) return string.Empty;

            var parameters = new StringBuilder();
            for (var i = 0; i < paramNames.Length; i++)
            {
                parameters.AppendFormat("{0}={1}", paramNames[i], paramValues[i] ?? "<NULL>");
                if (i < paramNames.Length - 1) parameters.Append(", ");
            }
            return parameters.ToString();
        }

        void DoLog(string message)
        {
            //do the actual logging in your favourite logging framework

            
            LoggedLines.Add(message);
        }

        public static readonly List<string> LoggedLines = new List<string>();
    }
}
