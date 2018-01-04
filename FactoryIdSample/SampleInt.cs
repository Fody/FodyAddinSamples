using Xunit;
using FactoryId;
using System;
using static ColorEnum;
// ReSharper disable JoinDeclarationAndInitializer

public class FactoriesSampleInt
{
    [Fact]
    public void FactoryEnumAuto()
    {
        ColorInt color;

        color = ColorInt.Factory(Black);
        Assert.NotNull(color as ColorIntBlack);

        color = ColorInt.Factory(White);
        Assert.NotNull(color as ColorIntWhite);

        color = ColorInt.Factory(Red);
        Assert.NotNull(color as ColorIntRed);

        color = ColorInt.Factory(Green);
        Assert.NotNull(color as ColorIntGreen);

        color = ColorInt.Factory(Blue);
        Assert.NotNull(color as ColorIntBlue);
    }

    [Fact]
    public void FactoryEnumAutoValues()
    {
        ColorInt mycolor;
        mycolor = ColorInt.Factory(Black);
        Assert.Equal("0x000000", mycolor.Content);

        mycolor = ColorInt.Factory(White);
        Assert.Equal("0xFFFFFF", mycolor.Content);

        mycolor = ColorInt.Factory(Red);
        Assert.Equal("0xFF0000", mycolor.Content);

        mycolor = ColorInt.Factory(Green);
        Assert.Equal("0x00FF00", mycolor.Content);

        mycolor = ColorInt.Factory(Blue);
        Assert.Equal("0x0000FF", mycolor.Content);
    }

    [Fact]
    public void FactoryEnumAutoGetKey()
    {
        foreach (ColorEnum v in Enum.GetValues(typeof(ColorEnum)))
        {
            var color = ColorInt.Factory(v);
            Assert.Equal(color.Key, v);
        }

    }

    [Fact]
    public void FactoryInt()
    {
        SomeColor mycolor;

        mycolor = SomeColor.Factory(0x000000);
        Assert.NotNull(mycolor as SomeColorBlack);

        mycolor = SomeColor.Factory(0xffffff);
        Assert.NotNull(mycolor as SomeColorWhite);

        mycolor = SomeColor.Factory(0xff0000);
        Assert.NotNull(mycolor as SomeColorRed);

        mycolor = SomeColor.Factory(0x00ff00);
        Assert.NotNull(mycolor as SomeColorGreen);

        mycolor = SomeColor.Factory(0x0000ff);
        Assert.NotNull(mycolor as SomeColorBlue);
    }

    [Fact]
    public void FactoryIntValues()
    {
        SomeColor mycolor;
        mycolor = SomeColor.Factory(0x000000);
        Assert.Equal("0x000000", mycolor.Content);

        mycolor = SomeColor.Factory(0xFFFFFF);
        Assert.Equal("0xFFFFFF", mycolor.Content);

        mycolor = SomeColor.Factory(0xFF0000);
        Assert.Equal("0xFF0000", mycolor.Content);

        mycolor = SomeColor.Factory(0x00FF00);
        Assert.Equal("0x00FF00", mycolor.Content);

        mycolor = SomeColor.Factory(0x0000FF);
        Assert.Equal("0x0000FF", mycolor.Content);
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