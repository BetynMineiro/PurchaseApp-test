// See https://aka.ms/new-console-template for more information

using PruchaseApp;

var items = new List<PurchaseItem>();
Console.WriteLine(" Enter Purchase Items type 'exit' to finish process");

while (true)
{
    Console.Write("Item Name: ");
    var name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name) || name == "exit")
    {
        break;
    }
    
    Console.Write("Item Price: ");
    if (!decimal.TryParse(Console.ReadLine(), out var price))
    {
        Console.WriteLine("value must be a decimal");
        continue;
    }
    
    items.Add(new PurchaseItem(name, price));

    if (!items.Any())
    {
        Console.WriteLine("No items added");
        return;
    }
    
    Console.WriteLine("");
    Console.WriteLine("enter US state to calculate tax");
    
    var state = Console.ReadLine() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(state))
    {
        Console.WriteLine("No state entered");
    }
    
    var category = StateTaxProvider.GetTaxCategory(state);
    var taxRate = StateTaxProvider.GetTaxRate(category);
    var subTotal = PurchaseCalculator.CalculateSubTotal(items);
    var tax = PurchaseCalculator.CalculateTax(subTotal, taxRate);
    var total = PurchaseCalculator.CalculateTotal(subTotal, tax);
    
    Console.WriteLine($"Summary for state {state}");
    Console.WriteLine($"Subtotal: {subTotal:C}");
    Console.WriteLine($"Tax: {tax:C}");
    Console.WriteLine($"Total: {total:C}");
    
}