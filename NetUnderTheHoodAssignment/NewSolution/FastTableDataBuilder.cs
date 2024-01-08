using CsvDataAccess.CsvReading;
using CsvDataAccess.Interface;

namespace CsvDataAccess.NewSolution;

public class FastTableDataBuilder : ITableDataBuilder
{
    enum CellType
    {
        String,
        Bool,
        Int,
        Floating,
        Null
    }

    public ITableData Build(CsvData csvData)
    {
        var resultRows = new List<Row2>();

        foreach (var line in csvData.Rows)
        {
            var columnCounter = 0;
            var creatingRow = new Row2();
            foreach (var cell in line)
            {
                var cellType = GetCellType(cell);
                var column = csvData.Columns[columnCounter];
             
                switch (cellType)
                {
                    case CellType.Bool:
                        var valueAsBool = ConvertCellToBool(cell);
                        creatingRow.addCellValue(column, valueAsBool);
                        break;
                    case CellType.Floating:
                        var valueAsDecimal = ConvertCellToFloating(cell);
                        creatingRow.addCellValue(column, valueAsDecimal);
                        break;
                    case CellType.Int:
                        var valueAsInt = ConvertCellToInt(cell);
                        creatingRow.addCellValue(column, valueAsInt);
                        break;
                    case CellType.String:
                        var valueAsString = ConvertCellToString(cell);
                        creatingRow.addCellValue(column, valueAsString);
                        break;
                    case CellType.Null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                columnCounter++;
            }
            resultRows.Add(creatingRow);
        }

        return new TableData(csvData.Columns, resultRows);
    }

    private CellType GetCellType(string? cell)
    {
        if (string.IsNullOrEmpty(cell))
            return CellType.Null;
        if (cell == "TRUE" || cell == "FALSE")
            return CellType.Bool;
        if (cell.Contains(".") && float.TryParse(cell, NumberCulture.DecimalNumberStyle, NumberCulture.DecimalNumberCulture, out var _))
            return CellType.Floating;
        if (int.TryParse(cell, out var valueAsInt))
            return CellType.Int;

        return CellType.String;
    }

    private bool ConvertCellToBool(string? cell)
        => cell == "TRUE" ? true : cell == "FALSE" ? false : throw new InvalidCastException();
    private string ConvertCellToString(string cell)
        => cell;
    private int ConvertCellToInt(string? cell)
        => int.Parse(cell);
    private float ConvertCellToFloating(string? cell)
        => float.Parse(cell, NumberCulture.DecimalNumberStyle, NumberCulture.DecimalNumberCulture);
}