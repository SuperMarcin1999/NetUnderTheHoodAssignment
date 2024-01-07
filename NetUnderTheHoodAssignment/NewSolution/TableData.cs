using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

class TableData : ITableData
{
    public IEnumerable<string> Columns { get; }
    public int RowCount => _rows.Count;
    private List<Row2> _rows;

    public object? GetValue(string columnName, int rowIndex)
        => _rows[rowIndex].GetCellValueAtIndex(columnName);
    
    public TableData(IEnumerable<string> columns, List<Row2> rows)
    {
        Columns = columns;
        _rows = rows;
    }
}