namespace StaticProxyNinjectSample.Samples
{
    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using NUnit.Framework;

    [TestFixture]
    public class InterfaceProxySample
    {
        [Test]
        public void Run()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<IInterfaceToProxy>().ToProxy(x => x
                        .By<ConsoleLogInterceptor>()
                        .By<MultiplyingInterceptor>());

                int result = kernel.Get<IInterfaceToProxy>().Multiply(2, 5);

                Assert.AreEqual(result, 10);
            }
        }
    }
}