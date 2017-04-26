#pragma warning disable 414
public class Person : IFreezable
{
    bool isFrozen;
    public string Name { get; set; }

    public void Freeze()
    {
        isFrozen = true;
    }
}