namespace CsvDataAccess.NewSolution;

public class Row2
{
    private Dictionary<string, bool> _boolValues = new Dictionary<string, bool>();
    private Dictionary<string, string> _stringValues = new Dictionary<string, string>();
    private Dictionary<string, int> _intValues = new Dictionary<string, int>();
    private Dictionary<string, decimal> _decimalValues = new Dictionary<string, decimal>();
    private Dictionary<string, object?> _objectValues = new Dictionary<string, object?>();

    public void addCellValue(string col, bool value)
        => _boolValues[col] = value;
    public void addCellValue(string col, string value)
        => _stringValues[col] = value;
    public void addCellValue(string col, int value)
        => _intValues[col] = value;
    public void addCellValue(string col, decimal value)
        => _decimalValues[col] = value;
    public void addCellValue(string col, object? value)
        => _objectValues[col] = value;

    public object? GetCellValueAtIndex(string colName)
    {
        if (_boolValues.TryGetValue(colName, out var valueBool))
            return valueBool;
        if (_stringValues.TryGetValue(colName, out var valueString))
            return valueString;
        if (_intValues.TryGetValue(colName, out var valueInt))
            return valueInt;
        if (_decimalValues.TryGetValue(colName, out var valueDecimal))
            return valueDecimal;
        if (_objectValues.TryGetValue(colName, out var valueObject))
            return valueObject;

        return null;
    }
}