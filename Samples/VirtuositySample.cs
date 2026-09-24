
public class VirtuositySample
{
    [Test]
    public async Task Run() =>
        await Assert.That(typeof(Target).GetProperty("Property")!.GetMethod.IsVirtual).IsTrue();

    public class Target
    {
        public string Property { get; set; }
    }
}