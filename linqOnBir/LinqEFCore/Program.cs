using static System.Console;
using LinqEFCore;
using Microsoft.EntityFrameworkCore;


FilterAndSort();

static void FilterAndSort()
{
    using (Northwind db = new())
    {
        DbSet<Product> allProducts = db.Products;

        IQueryable<Product> filteredProducts =
            allProducts.Where(product => product.UnitPrice < 10M);

        IOrderedQueryable<Product> filteredAndSortedProducts =
            filteredProducts.OrderByDescending(product => product.UnitPrice);

        WriteLine("Products that cost less than $10:");
        foreach (Product p in filteredAndSortedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
            p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }
}