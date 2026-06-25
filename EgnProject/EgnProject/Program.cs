using System.Text;
using EgnProject;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("============================================================");
Console.WriteLine(" Bulgarian EGN generator");
Console.WriteLine(" *** SYNTHETIC TEST DATA ONLY — do not use for real people ***");
Console.WriteLine("============================================================");

Gender gender = ReadGender();
Region region = ReadRegion();
DateOnly birthDate = ReadBirthDate();

Console.WriteLine();
Console.WriteLine("Generating EGNs for:");
Console.WriteLine($"  Gender : {gender}");
Console.WriteLine($"  Region : {region}");
Console.WriteLine($"  Date   : {birthDate:yyyy-MM-dd}");
Console.WriteLine();

List<string> results = EgnGenerator.Generate(birthDate, region, gender).ToList();

Console.WriteLine($"{results.Count} valid EGN(s):");
Console.WriteLine();
foreach (string egn in results)
    Console.WriteLine($"  {egn}");

Console.WriteLine();
Console.WriteLine("Done.");

return;

// ---------------------------------------------------------------------------
// Console input helpers
// ---------------------------------------------------------------------------

static Gender ReadGender()
{
    Console.WriteLine();
    while (true)
    {
        Console.Write("Gender (0 = Male, 1 = Female): ");
        string input = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
        switch (input)
        {
            case "0" or "m" or "male":
                return Gender.Male;
            case "1" or "f" or "female":
                return Gender.Female;
            default:
                Console.WriteLine("  Please enter 0 (Male) or 1 (Female).");
                break;
        }
    }
}

static Region ReadRegion()
{
    Console.WriteLine();
    Console.WriteLine("Available regions:");
    for (int i = 0; i < Regions.All.Count; i++)
    {
        Region r = Regions.All[i];
        Console.WriteLine($"  {i + 1,2}. {r.Name,-16} {r.Low:D3}–{r.High:D3}");
    }
    Console.WriteLine();

    while (true)
    {
        Console.Write("Select region by list number, name, or serial code (0–999): ");
        string input = (Console.ReadLine() ?? string.Empty).Trim();
        if (input.Length == 0)
        {
            Console.WriteLine("  Please enter a value.");
            continue;
        }

        if (int.TryParse(input, out int number))
        {
            // A value in 1..N is treated as a list selection first.
            if (number >= 1 && number <= Regions.All.Count)
                return Regions.All[number - 1];

            // Otherwise interpret it as a serial code (0–999).
            Region? byCode = Regions.FindByCode(number);
            if (byCode is not null)
                return byCode;
        }
        else
        {
            Region? byName = Regions.FindByName(input);
            if (byName is not null)
                return byName;
        }

        Console.WriteLine($"  '{input}' did not match any region — try again.");
    }
}

static DateOnly ReadBirthDate()
{
    Console.WriteLine();
    while (true)
    {
        int day = ReadInt("Birth day (1–31): ", 1, 31);
        int month = ReadInt("Birth month (1–12): ", 1, 12);
        int year = ReadInt("Birth year (1800–2099): ", 1800, 2099);

        if (day <= DateTime.DaysInMonth(year, month))
            return new DateOnly(year, month, day);

        Console.WriteLine($"  {day:D2}.{month:D2}.{year} is not a real calendar date — try again.");
        Console.WriteLine();
    }
}

static int ReadInt(string prompt, int min, int max)
{
    while (true)
    {
        Console.Write(prompt);
        string input = (Console.ReadLine() ?? string.Empty).Trim();
        if (int.TryParse(input, out int value) && value >= min && value <= max)
            return value;

        Console.WriteLine($"  Please enter a whole number between {min} and {max}.");
    }
}
