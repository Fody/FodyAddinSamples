using Microsoft.Extensions.Logging;

namespace LoggerIsEnabledSample
{
    public class ClassWithLogging
    {
        private readonly ILogger<ClassWithLogging> _logger;

        public ClassWithLogging(ILogger<ClassWithLogging> logger)
        {
            _logger = logger;
        }

        public void LogTrace()
        {
            _logger.LogTrace("message");
        }
    }
}