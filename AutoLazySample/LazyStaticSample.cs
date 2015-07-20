using System;
using AutoLazy;
using NUnit.Framework;

namespace AutoLazySample
{
    [TestFixture]
    public class LazyStaticSample
    {
        static int getGuidStringCallCount;
        static int guidStringCallCount;

        [Lazy]
        public static string GetGuidString()
        {
            ++getGuidStringCallCount;
            return Guid.NewGuid().ToString();
        }

        [Lazy]
        public static string GuidString
        {
            get
            {
                ++guidStringCallCount;
                return Guid.NewGuid().ToString();
            }
        }

        [Test]
        public void GetGuidStringShouldBeCalledOnlyOnce()
        {
            Assert.AreEqual(0, getGuidStringCallCount);
            var first = GetGuidString();
            Assert.AreEqual(1, getGuidStringCallCount);
            var second = GetGuidString();
            Assert.AreEqual(first, second);
            Assert.AreEqual(1, getGuidStringCallCount);
        }

        [Test]
        public void GuidStringShouldBeCalledOnlyOnce()
        {
            Assert.AreEqual(0, guidStringCallCount);
            var first = GuidString;
            Assert.AreEqual(1, guidStringCallCount);
            var second = GuidString;
            Assert.AreEqual(first, second);
            Assert.AreEqual(1, guidStringCallCount);
        }
    }
}
