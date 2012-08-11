public class Person : IFreezable
{
// ReSharper disable NotAccessedField.Local
    bool isFrozen;
// ReSharper restore NotAccessedField.Local
    public string Name { get; set; }

    public void Freeze()
    {
        isFrozen = true;
    }
}