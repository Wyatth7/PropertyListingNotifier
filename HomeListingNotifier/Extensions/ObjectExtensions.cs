using System.Text.RegularExpressions;

namespace HomeListingNotifier.Extensions;

/// <summary>
/// The HOLY copy/paste hell
/// </summary>
public static partial class ObjectExtensions
{
    public static float AsFloat(this object? value)
    {
        if (value is null) return 0;

        try
        {
            var valid = float.TryParse(Strip(value), out var result);

            return valid ? result : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("String value could not be converted to a float, returning 0.");
            return 0;
        }
    }
    
    public static decimal AsCurrency(this object? value)
    {
        if (value is null) return 0;

        try
        {
            var valid = decimal.TryParse(Strip(value), out var result);

            return valid ? result : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("String value could not be converted to a decimal, returning 0.");
            return 0;
        }
    }

    public static int AsInt32(this object? value)
    {
        if (value is null) return 0;

        try
        {
            var valid = int.TryParse(Strip(value), out var result);

            return valid ? result : 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("String value could not be converted to a float, returning 0.");
            return 0;
        }
    }

    private static string Strip(object value)
    {
        return NumericOnlyRegex().Replace(value.ToString() ?? string.Empty, "");
    }

    [GeneratedRegex(@"(?!^)-|[^0-9.-]|(?<=\..*)\.")]
    private static partial Regex NumericOnlyRegex();
}