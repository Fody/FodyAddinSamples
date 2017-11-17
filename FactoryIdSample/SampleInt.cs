using NUnit.Framework;
using FactoryId;
using System;
using static ColorEnum;

[TestFixture]
public class FactoriesSampleInt
{
    [Test]
    public void FactoryEnumAuto()
    {
        ColorInt mycolor = null;

        mycolor = ColorInt.Factory(Black);
        Assert.IsNotNull(mycolor as ColorIntBlack);

        mycolor = ColorInt.Factory(White);
        Assert.IsNotNull(mycolor as ColorIntWhite);

        mycolor = ColorInt.Factory(Red);
        Assert.IsNotNull(mycolor as ColorIntRed);

        mycolor = ColorInt.Factory(Green);
        Assert.IsNotNull(mycolor as ColorIntGreen);

        mycolor = ColorInt.Factory(Blue);
        Assert.IsNotNull(mycolor as ColorIntBlue);
    }

    [Test]
    public void FactoryEnumAutoValues()
    {
        ColorInt mycolor = null;
        mycolor = ColorInt.Factory(Black);
        Assert.AreEqual(mycolor.Content, "0x000000");

        mycolor = ColorInt.Factory(White);
        Assert.AreEqual(mycolor.Content, "0xFFFFFF");

        mycolor = ColorInt.Factory(Red);
        Assert.AreEqual(mycolor.Content, "0xFF0000");

        mycolor = ColorInt.Factory(Green);
        Assert.AreEqual(mycolor.Content, "0x00FF00");

        mycolor = ColorInt.Factory(Blue);
        Assert.AreEqual(mycolor.Content, "0x0000FF");
    }

    [Test]
    public void FactoryEnumAutoGetKey()
    {
        foreach (ColorEnum v in Enum.GetValues(typeof(ColorEnum)))
        {
            var color = ColorInt.Factory(v);
            Assert.AreEqual(color.Key, v);
        }

    }

    [Test]
    public void FactoryInt()
    {
        SomeColor mycolor = null;

        mycolor = SomeColor.Factory(0x000000);
        Assert.IsNotNull(mycolor as SomeColorBlack);

        mycolor = SomeColor.Factory(0xffffff);
        Assert.IsNotNull(mycolor as SomeColorWhite);

        mycolor = SomeColor.Factory(0xff0000);
        Assert.IsNotNull(mycolor as SomeColorRed);

        mycolor = SomeColor.Factory(0x00ff00);
        Assert.IsNotNull(mycolor as SomeColorGreen);

        mycolor = SomeColor.Factory(0x0000ff);
        Assert.IsNotNull(mycolor as SomeColorBlue);
    }

    [Test]
    public void FactoryIntValues()
    {
        SomeColor mycolor = null;
        mycolor = SomeColor.Factory(0x000000);
        Assert.AreEqual(mycolor.Content, "0x000000");

        mycolor = SomeColor.Factory(0xFFFFFF);
        Assert.AreEqual(mycolor.Content, "0xFFFFFF");

        mycolor = SomeColor.Factory(0xFF0000);
        Assert.AreEqual(mycolor.Content, "0xFF0000");

        mycolor = SomeColor.Factory(0x00FF00);
        Assert.AreEqual(mycolor.Content, "0x00FF00");

        mycolor = SomeColor.Factory(0x0000FF);
        Assert.AreEqual(mycolor.Content, "0x0000FF");
    }
}

public enum ColorEnum
{
    Black,
    White,
    Red,
    Green,
    Blue
}

[FactoryIntBaseAuto(typeof(ColorEnum))]
public abstract class ColorInt
{
#pragma warning disable RECS0154 // Parameter is never used
    public static ColorInt FactoryInt(int color) => null;
#pragma warning restore RECS0154 // Parameter is never used
    public static ColorInt Factory(ColorEnum color) => FactoryInt((int) color);
    public abstract string Content { get; }
    public ColorEnum Key => (ColorEnum) GetType().GetProperty("FactoryIntKey", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null);
}

public class ColorIntBlack : ColorInt
{
    public override string Content => "0x000000";
}

public class ColorIntWhite : ColorInt
{
    public override string Content => "0xFFFFFF";
}

public class ColorIntRed : ColorInt
{
    public override string Content => "0xFF0000";
}

public class ColorIntGreen : ColorInt
{
    public override string Content => "0x00FF00";
}

public class ColorIntBlue : ColorInt
{
    public override string Content => "0x0000FF";
}

[FactoryIntBase]
public abstract class SomeColor
{
#pragma warning disable RECS0154 // Parameter is never used
    public static SomeColor FactoryInt(int color) => null;
#pragma warning restore RECS0154 // Parameter is never used
    public static SomeColor Factory(int color) => FactoryInt(color);

    public string Content => $"0x{Key:X6}";
    public int Key => (int) GetType().GetProperty("FactoryIntKey", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null);
}

[FactoryIntKey(0)]
public class SomeColorBlack : SomeColor
{
}

[FactoryIntKey(0xffffff)]
public class SomeColorWhite : SomeColor
{
}

[FactoryIntKey(0xff0000)]
public class SomeColorRed : SomeColor
{
}

[FactoryIntKey(0x00ff00)]
public class SomeColorGreen : SomeColor
{
}

[FactoryIntKey(0x0000ff)]
public class SomeColorBlue : SomeColor
{
}