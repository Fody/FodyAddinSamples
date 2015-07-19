using System;
using System.Linq;
using AutoLazy;
using NUnit.Framework;

namespace AutoLazySample
{
    [TestFixture]
    public class LazyInstanceSample
    {
        private int _getGuidStringCallCount;
        private int _guidStringCallCount;

        [Lazy]
        public string GetGuidString()
        {
            ++_getGuidStringCallCount;
            return Guid.NewGuid().ToString();
        }

        [Lazy]
        
        public string GuidString
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
