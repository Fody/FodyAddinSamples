using Xunit;
using FactoryId;

public class FactoriesSampleStr
{
    [Fact]
    public void FactoryStrAuto()
    {
        Color mycolor = null;

        mycolor = Color.Factory("Black");
        Assert.NotNull(mycolor as ColorBlack);

        mycolor = Color.Factory("White");
        Assert.NotNull(mycolor as ColorWhite);

        mycolor = Color.Factory("Red");
        Assert.NotNull(mycolor as ColorRed);

        mycolor = Color.Factory("Green");
        Assert.NotNull(mycolor as ColorGreen);

        mycolor = Color.Factory("Blue");
        Assert.NotNull(mycolor as ColorBlue);
    }

    [Fact]
    public void FactoryStrAutoValues()
    {
        Color mycolor = null;
        mycolor = Color.Factory("Black");
        Assert.Equal("0x000000", mycolor.Content);

        mycolor = Color.Factory("White");
        Assert.Equal("0xFFFFFF", mycolor.Content);

        mycolor = Color.Factory("Red");
        Assert.Equal("0xFF0000", mycolor.Content);

        mycolor = Color.Factory("Green");
        Assert.Equal("0x00FF00", mycolor.Content);

        mycolor = Color.Factory("Blue");
        Assert.Equal("0x0000FF", mycolor.Content);
    }

    [Fact]
    public void FactoryStrAutoGetKey()
    {
        foreach (var v in ColorKeys)
        {
            var color = Color.Factory(v);
            Assert.Equal(color.Key, v);
        }

    }

    [Fact]
    public void FactoryStr()
    {
        SpanishColor mycolor = null;

        mycolor = SpanishColor.Factory("Black");
        Assert.NotNull(mycolor as ColorNegro);

        mycolor = SpanishColor.Factory("White");
        Assert.NotNull(mycolor as ColorBlanco);

        mycolor = SpanishColor.Factory("Red");
        Assert.NotNull(mycolor as ColorRojo);

        mycolor = SpanishColor.Factory("Green");
        Assert.NotNull(mycolor as ColorVerde);

        mycolor = SpanishColor.Factory("Blue");
        Assert.NotNull(mycolor as ColorAzul);
    }

    [Fact]
    public void FactoryStrValues()
    {
        SpanishColor mycolor = null;
        mycolor = SpanishColor.Factory("Black");
        Assert.Equal("0x000000", mycolor.Content);

        mycolor = SpanishColor.Factory("White");
        Assert.Equal("0xFFFFFF", mycolor.Content);

        mycolor = SpanishColor.Factory("Red");
        Assert.Equal("0xFF0000", mycolor.Content);

        mycolor = SpanishColor.Factory("Green");
        Assert.Equal("0x00FF00", mycolor.Content);

        mycolor = SpanishColor.Factory("Blue");
        Assert.Equal("0x0000FF", mycolor.Content);
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