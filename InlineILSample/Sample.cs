using System;

public class Sample
{
    [Test]
    public async Task Run()
    {
        var item = new MyStruct
        {
            Int = 42,
            Guid = Guid.NewGuid()
        };

        ZeroInit.InitStruct(ref item);

        await Assert.That(item.Int).IsEqualTo(0);
        await Assert.That(item.Guid).IsEqualTo(Guid.Empty);
    }

    struct MyStruct
    {
        public int Int;
        public Guid Guid;
    }
}