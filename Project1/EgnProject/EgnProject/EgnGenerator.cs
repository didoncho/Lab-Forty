namespace EgnProject;

/// <summary>Gender as encoded by the EGN's 9th digit.</summary>
public enum Gender
{
    Male = 0,   // even 9th digit
    Female = 1, // odd 9th digit
}

/// <summary>
/// Generates valid synthetic Bulgarian EGN numbers (format YYMMDDSSSC) and
/// computes the official checksum digit. For test data generation only.
/// </summary>
public static class EgnGenerator
{
    // Official checksum weights for the first nine digits.
    private static readonly int[] Weights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

    /// <summary>
    /// Encodes the birth month according to the century of the birth year:
    /// 1800–1899 → month + 20, 1900–1999 → month, 2000–2099 → month + 40.
    /// </summary>
    public static int EncodeMonth(int year, int month)
    {
        if (month is < 1 or > 12)
            throw new ArgumentOutOfRangeException(nameof(month), month, "Month must be between 1 and 12.");

        return year switch
        {
            >= 1800 and <= 1899 => month + 20,
            >= 1900 and <= 1999 => month,
            >= 2000 and <= 2099 => month + 40,
            _ => throw new ArgumentOutOfRangeException(nameof(year), year,
                "Year must be within 1800–2099 to be representable as an EGN."),
        };
    }

    /// <summary>
    /// Computes the EGN checksum (10th digit) from the first nine digits using
    /// the official weights. A remainder of 10 maps to 0.
    /// </summary>
    public static int Checksum(ReadOnlySpan<int> firstNine)
    {
        if (firstNine.Length != 9)
            throw new ArgumentException("Exactly nine digits are required.", nameof(firstNine));

        int sum = 0;
        for (int i = 0; i < firstNine.Length; i++)
            sum += firstNine[i] * Weights[i];

        int remainder = sum % 11;
        return remainder == 10 ? 0 : remainder;
    }

    /// <summary>
    /// Generates every valid EGN matching the given date, region and gender.
    /// The serial number (digits 7–9) is enumerated across the region's range;
    /// its parity selects gender — even for male, odd for female.
    /// </summary>
    public static IEnumerable<string> Generate(DateOnly birthDate, Region region, Gender gender)
    {
        ArgumentNullException.ThrowIfNull(region);

        int yy = birthDate.Year % 100;
        int mm = EncodeMonth(birthDate.Year, birthDate.Month);
        int dd = birthDate.Day;

        for (int serial = region.Low; serial <= region.High; serial++)
        {
            // The 9th digit (serial's last digit) carries gender; its parity
            // equals the parity of the whole serial.
            bool isEven = serial % 2 == 0;
            bool matchesGender = gender == Gender.Male ? isEven : !isEven;
            if (!matchesGender)
                continue;

            int[] digits =
            [
                yy / 10, yy % 10,
                mm / 10, mm % 10,
                dd / 10, dd % 10,
                serial / 100, serial / 10 % 10, serial % 10,
            ];

            int check = Checksum(digits);
            yield return $"{yy:D2}{mm:D2}{dd:D2}{serial:D3}{check}";
        }
    }
}
