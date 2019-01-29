using System;
using System.Collections.Generic;
using System.ComponentModel;
using Mimick;
using Mimick.Configurations;
using Xunit;

namespace MimickSample
{
    /// <summary>
    /// A class containing the test needed 
    /// </summary>
    public class Sample : IDisposable
    {
        [Autowire]
        private SampleService service;

        /// <summary>
        /// Configure the Mimick framework prior to the tests being run.
        /// </summary>
        public Sample()
        {
            var framework = FrameworkContext.Current;
            var components = framework.ComponentContext;
            var configuration = framework.ConfigurationContext;

            var values = new Dictionary<string, string>();

            values.Add("Message", "Hello world");
            configuration.Register(new KeyValueConfigurationSource(values));

            components.RegisterAssembly<Sample>();
            framework.Initialize();
        }

        /// <summary>
        /// Release the Mimick framework once the tests have completed.
        /// </summary>
        public void Dispose()
        {
            FrameworkContext.Current.Dispose();
        }

        /// <summary>
        /// Runs the tests associated with the sample.
        /// </summary>
        [Fact]
        public void Run()
        {
            Assert.NotNull(service);

            RunConfigurationValues();
            RunConstructors();
            RunPropertyChange();
            RunSuppress();
            RunValidation();
        }

        /// <summary>
        /// Runs the tests which check for valid configuration values.
        /// </summary>
        private void RunConfigurationValues()
        {
            Assert.Equal("Mimick Sample", service.ApplicationName);
            Assert.Equal(1234, service.ApplicationId);
            Assert.Equal("Hello world", service.GetMessage());
        }

        /// <summary>
        /// Runs the tests which check for valid constructor count.
        /// </summary>
        private void RunConstructors()
        {
            Assert.Equal(2, service.ConstructCount);
        }

        /// <summary>
        /// Runs the tests which check whether interfaces are implemented correctly.
        /// </summary>
        private void RunPropertyChange()
        {
            var model = new SampleModel();
            var observable = model as INotifyPropertyChanged;
            var match = new List<string>();

            Assert.NotNull(observable);

            observable.PropertyChanged += (sender, e) => match.Add(e.PropertyName);

            model.Id = 1;
            model.Name = "Test";
            model.Tag = 10;

            Assert.Contains("Id", match);
            Assert.Contains("Name", match);
            Assert.DoesNotContain("Tag", match);
        }

        /// <summary>
        /// Runs the tests which check whether exception suppression works.
        /// </summary>
        private void RunSuppress()
        {
            var value = service.ThrowAndIgnore(new Exception());

            Assert.Equal(0, value);
        }

        /// <summary>
        /// Runs the tests which perform basic validation.
        /// </summary>
        private void RunValidation()
        {
            Assert.Throws<ArgumentNullException>(() => service.CheckNotNull(null));
            service.CheckNotNull(new object());

            Assert.Throws<ArgumentException>(() => service.CheckNotEmpty(null));
            Assert.Throws<ArgumentException>(() => service.CheckNotEmpty(""));
            service.CheckNotEmpty("test");

            Assert.Throws<ArgumentOutOfRangeException>(() => service.CheckIsShortValue(int.MinValue));
            Assert.Throws<ArgumentOutOfRangeException>(() => service.CheckIsShortValue(int.MaxValue));
            service.CheckIsShortValue(short.MinValue);
            service.CheckIsShortValue(0);
            service.CheckIsShortValue(short.MaxValue);
        }
    }
}
