namespace StaticProxyUnitySample.Samples
{
    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    using Unity.StaticProxyExtension;

    [TestFixture]
    public class InterfaceProxySample
    {
        [Test]
        public void Run()
        {
            using (var container = new UnityContainer())
            {
                container.AddNewExtension<StaticProxyExtension>();
                container.RegisterInterfaceProxy<IInterfaceToProxy>(
                    new Intercept<ConsoleLogInterceptor>(),
                    new Intercept<MultiplyingInterceptor>());

                int result = container.Resolve<IInterfaceToProxy>().Multiply(2, 5);

                Assert.AreEqual(result, 10);
            }
        }
    }
}