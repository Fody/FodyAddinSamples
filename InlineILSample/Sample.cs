using System;
using Xunit;

namespace InlineILSample
{
    public class Sample
    {
        [Fact]
        public void Run()
        {
            var item = new MyStruct
            {
                Int = 42,
                Guid = Guid.NewGuid()
            };

            ZeroInit.InitStruct(ref item);

            Assert.Equal(0, item.Int);
            Assert.Equal(Guid.Empty, item.Guid);
        }

        struct MyStruct
        {
            public int Int;
            public Guid Guid;
        }
    }
}