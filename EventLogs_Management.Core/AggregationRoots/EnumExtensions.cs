namespace EventLogs_Management.Core.AggregationRoots;

public static class EnumExtensions
{
    public static T ToEnum<T>(this string value) where T : struct, IConvertible
    {
        if (!Enum.TryParse(value, true, out T result))
            return default;

        if (!Enum.IsDefined(typeof(T), result))
            return default;

        return result;
    }

    public static bool IsEnumValue<T>(this string input) where T : struct
    {
        return Enum.TryParse<T>(input, out _);
    }
}
