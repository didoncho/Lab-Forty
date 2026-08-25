using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace ServiceLayer;

public class CsvImportService
{
    private static readonly CsvConfiguration Config = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = true,
        TrimOptions    = TrimOptions.Trim,
        IgnoreBlankLines = true,
        DetectDelimiter  = true   // handles both , and ; files
    };

    /// <summary>Reads every row of a CSV stream into an array of T.</summary>
    public async Task<T[]> ReadAsync<T>(Stream stream, CancellationToken ct = default)
    {
        using var reader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true);
        using var csv = new CsvReader(reader, Config);

        var rows = new List<T>();
        await foreach (var row in csv.GetRecordsAsync<T>(ct))
        {
            rows.Add(row);
        }
        return rows.ToArray();
    }
}