using static System.Console;
using EFCore;
using Microsoft.EntityFrameworkCore;

WriteLine($"Using \"{ProjectConstants.DatabaseProvider}\" provider");

//QueryingCategories();
static void QueryingCategories()
{
    using (Northwind db = new())
    {
        WriteLine("Categories and how many products they have:");
        
        IQueryable<Category>? categories = db.Categories?
        .Include(c => c.Products);
        if (categories is null)
        {
            WriteLine("No categories found.");
            return;
        }
       
        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }
    }
}