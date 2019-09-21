﻿using Xunit;
using Resourcer;

public class ResourcerSample
{
    [Fact]
    public void Run()
    {
        var fromResource = Resource.AsString("Resource.txt");
        Assert.Equal("Hello", fromResource);
    }
}