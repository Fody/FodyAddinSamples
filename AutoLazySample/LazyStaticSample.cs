using System;
using System.Linq;
using AutoLazy;
using NUnit.Framework;

namespace AutoLazySample
{
    [TestFixture]
    public class LazyStaticSample
    {
        private static int _getGuidStringCallCount;
        private static int _guidStringCallCount;

        [Lazy]
        public static string GetGuidString()
        {
            ++_getGuidStringCallCount;
            return Guid.NewGuid().ToString();
        }

        [Lazy]
        
        public static string GuidString
        {
            get
            {
                ++_guidStringCallCount;
                return Guid.NewGuid().ToString();
            }
        }

        [Test]
        public void GetGuidStringShouldBeCalledOnlyOnce()
        {
            Assert.AreEqual(0, _getGuidStringCallCount);
            var first = GetGuidString();
            Assert.AreEqual(1, _getGuidStringCallCount);
            var second = GetGuidString();
            Assert.AreEqual(first, second);
            Assert.AreEqual(1, _getGuidStringCallCount);
        }

        [Test]
        public void GuidStringShouldBeCalledOnlyOnce()
        {
            Assert.AreEqual(0, _guidStringCallCount);
            var first = GuidString;
            Assert.AreEqual(1, _guidStringCallCount);
            var second = GuidString;
            Assert.AreEqual(first, second);
            Assert.AreEqual(1, _guidStringCallCount);
        }
    }
}
