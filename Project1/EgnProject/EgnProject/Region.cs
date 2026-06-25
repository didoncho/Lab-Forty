namespace EgnProject;

/// <summary>
/// A Bulgarian administrative region together with the inclusive range of
/// serial numbers (EGN digits 7–9) historically associated with it.
/// </summary>
public sealed record Region(string Name, int Low, int High)
{
    /// <summary>True when <paramref name="serial"/> falls inside this region's range.</summary>
    public bool Contains(int serial) => serial >= Low && serial <= High;

    public override string ToString() => $"{Name} ({Low:D3}–{High:D3})";
}

/// <summary>
/// The full table of region serial ranges used to interpret the 7th–9th EGN
/// digits by birth region.
/// </summary>
public static class Regions
{
    public static readonly IReadOnlyList<Region> All = new List<Region>
    {
        new("Blagoevgrad",    000, 043),
        new("Burgas",         044, 093),
        new("Varna",          094, 139),
        new("Veliko Tarnovo", 140, 169),
        new("Vidin",          170, 183),
        new("Vratsa",         184, 217),
        new("Gabrovo",        218, 233),
        new("Kardzhali",      234, 281),
        new("Kyustendil",     282, 301),
        new("Lovech",         302, 319),
        new("Montana",        320, 341),
        new("Pazardzhik",     342, 377),
        new("Pernik",         378, 395),
        new("Pleven",         396, 435),
        new("Plovdiv",        436, 501),
        new("Razgrad",        502, 527),
        new("Ruse",           528, 555),
        new("Silistra",       556, 575),
        new("Sliven",         576, 601),
        new("Smolyan",        602, 623),
        new("Sofia City",     624, 721),
        new("Sofia Region",   722, 751),
        new("Stara Zagora",   752, 789),
        new("Dobrich",        790, 821),
        new("Targovishte",    822, 843),
        new("Haskovo",        844, 871),
        new("Shumen",         872, 903),
        new("Yambol",         904, 925),
        new("Other/Unknown",  926, 999),
    };

    /// <summary>Finds a region by name (case-insensitive), or null if none matches.</summary>
    public static Region? FindByName(string name) =>
        All.FirstOrDefault(r => string.Equals(r.Name, name.Trim(), StringComparison.OrdinalIgnoreCase));

    /// <summary>Finds the region whose range contains the given serial code, or null.</summary>
    public static Region? FindByCode(int code) =>
        All.FirstOrDefault(r => r.Contains(code));
}
