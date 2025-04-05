namespace PruchaseApp;

public class PurchaseCalculator
{
    public static decimal CalculateSubTotal(IEnumerable<PurchaseItem> items) => items.Sum(i => i.Cost);
    public static decimal CalculateTax(decimal subTotal, decimal taxRate) => subTotal * taxRate;
    public static decimal CalculateTotal(decimal subTotal, decimal tax) => subTotal + tax;
}