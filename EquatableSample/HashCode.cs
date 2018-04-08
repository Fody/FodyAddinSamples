using System;

/// <summary>
/// Helper to generate hash codes
/// </summary>
public class HashCode
{
    /// <summary>
    /// Aggregates the specified values to a single hash code.
    /// </summary>
    /// <param name="hash1">The first hash code.</param>
    /// <param name="hash2">The second hash code.</param>
    /// <returns>A new hash code calculated from the specified ones.</returns>
    public static int Aggregate(int hash1, int hash2)
    {
        unchecked
        {
            return ((hash1 << 5) + hash1) ^ hash2;
        }
    }

    public static int GetHashCode(object value)
    {
        if (value == null)
        {
            return 0;
        }

        return value.GetHashCode();
    }

    public static int GetStringHashCode(string value, StringComparer comparer)
    {
        if (value == null)
        {
            return 0;
        }

        return comparer.GetHashCode(value);
    }
}