﻿
// ReSharper disable UnusedTypeParameter
namespace AnotarCustomSample;

public class LoggerFactory
{
    public static Logger GetLogger<T>() =>
        new();
}