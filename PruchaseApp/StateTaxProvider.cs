namespace PruchaseApp;

public static class StateTaxProvider
{
    private static readonly HashSet<string> HighStateTaxes = new() { "CA", "TX", "NY", "FL" };
    private static readonly HashSet<string> MediumStateTaxes = new() { "WC", "OR", "ID", "UT", "MT", "NM", "AZ", "KN", "AK", "GO", "AL", "WY" };

    public static TaxCategory GetTaxCategory(string state) =>
        HighStateTaxes.Contains(state) ? TaxCategory.High :
        MediumStateTaxes.Contains(state) ? TaxCategory.Medium :
        TaxCategory.None;

    public static decimal GetTaxRate(TaxCategory category) => Convert.ToDecimal(category) / 100;
}