using System;
using Mimick;

namespace MimickSample
{
    /// <summary>
    /// A service class which persists as a singleton within the framework.
    /// </summary>
    [Component]
    public class SampleService
    {
        [Value("{Message}")]
        string message;

        /// <summary>
        /// Gets the application name configured in the configuration class.
        /// </summary>
        [Value("{Application.Name}")]
        public string ApplicationName
        {
            get; set;
        }

        /// <summary>
        /// Gets the application ID configured in the configuration class.
        /// </summary>
        [Value("{Application.Id}")]
        public int ApplicationId
        {
            get; set;
        }

        /// <summary>
        /// Gets the internal constructor count.
        /// </summary>
        public int ConstructCount { get; private set; }

        /// <summary>
        /// Checks whether the provided argument falls within the bounds of a short value.
        /// </summary>
        /// <param name="data">The data.</param>
        public void CheckIsShortValue([Minimum(short.MinValue), Maximum(short.MaxValue)] int data) { }

        /// <summary>
        /// Checks whether the provided argument is not <c>null</c> or empty.
        /// </summary>
        /// <param name="str">The data.</param>
        public void CheckNotEmpty([NotEmpty] string str) { }

        /// <summary>
        /// Checks whether the provided argument is not <c>null</c>.
        /// </summary>
        /// <param name="data">The data.</param>
        public void CheckNotNull([NotNull] object data) { }

        /// <summary>
        /// Gets the message configured in the key-value configuration source.
        /// </summary>
        /// <returns></returns>
        public string GetMessage() => message;

        /// <summary>
        /// Invoked before the class constructor method body executes.
        /// </summary>
        [PreConstruct]
        void PreConstruct() => ConstructCount++;

        /// <summary>
        /// Invoked after the class constructor method body executes.
        /// </summary>
        [PostConstruct]
        void PostConstruct() => ConstructCount++;

        /// <summary>
        /// Throws an exception which should be consumed and ignored.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns>The default value of an integer.</returns>
        [Suppress]
        public int ThrowAndIgnore(Exception ex) => throw ex;
    }
}