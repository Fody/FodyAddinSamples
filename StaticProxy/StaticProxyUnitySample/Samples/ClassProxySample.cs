namespace StaticProxyUnitySample.Samples
{
    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    using Unity.StaticProxyExtension;

    [TestFixture]
    public class ClassProxySample
    {
        [Test]
        public void Run()
        {
            using (var container = new UnityContainer())
            {
                container.AddNewExtension<StaticProxyExtension>();
                container.RegisterType<ClassToProxy, ClassToProxy>(new Intercept<ConsoleLogInterceptor>());
                
                int result = container.Resolve<ClassToProxy>().Multiply(2, 5);

                Assert.AreEqual(result, 10);
            }
        }
    }
}