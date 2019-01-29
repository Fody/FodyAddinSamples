using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mimick;

namespace MimickSample
{
    /// <summary>
    /// A configuration class which provides configuration and component values.
    /// </summary>
    [Configuration]
    public class SampleConfiguration
    {
        /// <summary>
        /// Gets the application name.
        /// </summary>
        [Provide("Application.Name")]
        public string ApplicationName => "Mimick Sample";

        /// <summary>
        /// Gets the application ID.
        /// </summary>
        /// <returns></returns>
        [Provide("Application.Id")]
        public int GetApplicationId() => 1234;
    }
}
