using NUnit.Framework;
using FactoryId;

[TestFixture]
public class FactoriesSampleStr
{
    [Test]
    public void FactoryStrAuto()
    {
        Color mycolor = null;

        mycolor = Color.Factory("Black");
        Assert.IsNotNull(mycolor as ColorBlack);

        mycolor = Color.Factory("White");
        Assert.IsNotNull(mycolor as ColorWhite);

        mycolor = Color.Factory("Red");
        Assert.IsNotNull(mycolor as ColorRed);

        mycolor = Color.Factory("Green");
        Assert.IsNotNull(mycolor as ColorGreen);

        mycolor = Color.Factory("Blue");
        Assert.IsNotNull(mycolor as ColorBlue);
    }

    [Test]
    public void FactoryStrAutoValues()
    {
        Color mycolor = null;
        mycolor = Color.Factory("Black");
        Assert.AreEqual(mycolor.Content, "0x000000");

        mycolor = Color.Factory("White");
        Assert.AreEqual(mycolor.Content, "0xFFFFFF");

        mycolor = Color.Factory("Red");
        Assert.AreEqual(mycolor.Content, "0xFF0000");

        mycolor = Color.Factory("Green");
        Assert.AreEqual(mycolor.Content, "0x00FF00");

        mycolor = Color.Factory("Blue");
        Assert.AreEqual(mycolor.Content, "0x0000FF");
    }

    [Test]
    public void FactoryStrAutoGetKey()
    {
        foreach (var v in ColorKeys)
        {
            var color = Color.Factory(v);
            Assert.AreEqual(color.Key, v);
        }

    }

    [Test]
    public void FactoryStr()
    {
        SpanishColor mycolor = null;

        mycolor = SpanishColor.Factory("Black");
        Assert.IsNotNull(mycolor as ColorNegro);

        mycolor = SpanishColor.Factory("White");
        Assert.IsNotNull(mycolor as ColorBlanco);

        mycolor = SpanishColor.Factory("Red");
        Assert.IsNotNull(mycolor as ColorRojo);

        mycolor = SpanishColor.Factory("Green");
        Assert.IsNotNull(mycolor as ColorVerde);

        mycolor = SpanishColor.Factory("Blue");
        Assert.IsNotNull(mycolor as ColorAzul);
    }

    [Test]
    public void FactoryStrValues()
    {
        SpanishColor mycolor = null;
        mycolor = SpanishColor.Factory("Black");
        Assert.AreEqual(mycolor.Content, "0x000000");

        mycolor = SpanishColor.Factory("White");
        Assert.AreEqual(mycolor.Content, "0xFFFFFF");

        mycolor = SpanishColor.Factory("Red");
        Assert.AreEqual(mycolor.Content, "0xFF0000");

        mycolor = SpanishColor.Factory("Green");
        Assert.AreEqual(mycolor.Content, "0x00FF00");

        mycolor = SpanishColor.Factory("Blue");
        Assert.AreEqual(mycolor.Content, "0x0000FF");
    }

    public static string[] ColorKeys = {"Black", "White", "Red", "Green", "Blue"};
}

[FactoryStrBaseAuto]
public abstract class Color
{
#pragma warning disable RECS0154 // Parameter is never used
    public static Color FactoryStr(string color) => null;
#pragma warning restore RECS0154 // Parameter is never used
    public static Color Factory(string color) => FactoryStr(color);
    public abstract string Content { get; }
    public string Key => (string) GetType().GetProperty("FactoryStrKey", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null);
}

public class ColorBlack : Color
{
    public override string Content => "0x000000";
}

public class ColorWhite : Color
{
    public override string Content => "0xFFFFFF";
}

public class ColorRed : Color
{
    public override string Content => "0xFF0000";
}

public class ColorGreen : Color
{
    public override string Content => "0x00FF00";
}

public class ColorBlue : Color
{
    public override string Content => "0x0000FF";
}

[FactoryStrBase]
public abstract class SpanishColor
{
#pragma warning disable RECS0154 // Parameter is never used
    public static SpanishColor FactoryStr(string color) => null;
#pragma warning restore RECS0154 // Parameter is never used
    public static SpanishColor Factory(string color) => FactoryStr(color);

    public abstract string Content { get; }
    public string Key => (string) GetType().GetProperty("FactoryStrKey", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null);
}

[FactoryStrKey("Black")]
public class ColorNegro : SpanishColor
{
    public override string Content => "0x000000";
}

[FactoryStrKey("White")]
public class ColorBlanco : SpanishColor
{
    public override string Content => "0xFFFFFF";
}

[FactoryStrKey("Red")]
public class ColorRojo : SpanishColor
{
    public override string Content => "0xFF0000";
}

[FactoryStrKey("Green")]
public class ColorVerde : SpanishColor
{
    public override string Content => "0x00FF00";
}

[FactoryStrKey("Blue")]
public class ColorAzul : SpanishColor
{
    public override string Content => "0x0000FF";
}