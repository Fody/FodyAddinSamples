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
            DoLog($"Entered into {type.FullName} {methodInfo} ({BuildParameterInfo(paramNames, paramValues)})");
        }

        public void TraceLeave(string methodInfo, long start, long finish, string[] paramNames, object[] paramValues)
        {
            //do the actual logging
            DoLog($"Returned from {type.FullName} {methodInfo} ({BuildParameterInfo(paramNames, paramValues)})");
        }

        public void MyLogSomethingImportant(string methodInfo, int importantValue, string message)
        {
            DoLog($"Returned from {type.FullName} {methodInfo} (Msg={message}, ImportantValue is {importantValue})");
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
            //do the actual logging in your favorite logging framework

            
            LoggedLines.Add(message);
        }

        public static readonly List<string> LoggedLines = new List<string>();
    }
}
