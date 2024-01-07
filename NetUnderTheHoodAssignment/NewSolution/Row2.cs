namespace CsvDataAccess.NewSolution;

public class Row2
{
    private Dictionary<string, bool> _boolValues = new Dictionary<string, bool>();
    private Dictionary<string, string> _stringValues = new Dictionary<string, string>();
    private Dictionary<string, int> _intValues = new Dictionary<string, int>();
    private Dictionary<string, float> _floatValues = new Dictionary<string, float>();

    public void addCellValue(string col, bool value)
        => _boolValues[col] = value;
    public void addCellValue(string col, string value)
        => _stringValues[col] = value;
    public void addCellValue(string col, int value)
        => _intValues[col] = value;
    public void addCellValue(string col, float value)
        => _floatValues[col] = value;

    public object? GetCellValueAtIndex(string colName)
    {
        if (_boolValues.TryGetValue(colName, out var valueBool))
            return valueBool;
        if (_stringValues.TryGetValue(colName, out var valueString))
            return valueString;
        if (_intValues.TryGetValue(colName, out var valueInt))
            return valueInt;
        if (_floatValues.TryGetValue(colName, out var valueFloat))
            return valueFloat.ToString();

        return null;
    }
}