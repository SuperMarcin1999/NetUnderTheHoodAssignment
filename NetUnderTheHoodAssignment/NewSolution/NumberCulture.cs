using System.Globalization;

namespace CsvDataAccess.NewSolution;

public static class NumberCulture
{
    public static NumberStyles DecimalNumberStyle => NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
    public static CultureInfo DecimalNumberCulture => CultureInfo.InvariantCulture;
}