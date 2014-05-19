namespace StaticProxyNinjectSample.Samples
{
    using Ninject;
    using Ninject.Extensions.StaticProxy;

    using NUnit.Framework;

    [TestFixture]
    public class ClassProxySample
    {
        [Test]
        public void Run()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Bind<ClassToProxy>().ToSelf()
                    .Intercept(x => x
                        .By<ConsoleLogInterceptor>());

                int result = kernel.Get<ClassToProxy>().Multiply(2, 5);

                Assert.AreEqual(result, 10);
            }
        }
    }
}