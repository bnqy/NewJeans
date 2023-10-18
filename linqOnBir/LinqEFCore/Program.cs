﻿using static System.Console;
using LinqEFCore;
using Microsoft.EntityFrameworkCore;


//FilterAndSort();
//JoinCategoriesAndProducts();
//GroupJoinCategoriesAndProducts();
AggreagteMethod();

static void FilterAndSort()
{
    using (Northwind db = new())
    {
        DbSet<Product> allProducts = db.Products;

        IQueryable<Product> filteredProducts =
            allProducts.Where(product => product.UnitPrice < 10M);

        IOrderedQueryable<Product> filteredAndSortedProducts =
            filteredProducts.OrderByDescending(product => product.UnitPrice);


        var projectedProducts = filteredAndSortedProducts
            .Select(product => new 
            {
                product.ProductId,
                product.ProductName,
                product.UnitPrice
            });

        WriteLine("Products that cost less than $10:");

        foreach (var p in projectedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
            p.ProductId, p.ProductName, p.UnitPrice);
        }

        /*foreach (Product p in filteredAndSortedProducts)
        {           
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
            p.ProductId, p.ProductName, p.UnitPrice);
        }*/
        WriteLine();
    }
}

static void JoinCategoriesAndProducts()
{
    using (Northwind db = new())
    {
        var queryJoin = db.Categories.Join(
        inner: db.Products,
        outerKeySelector: category => category.CategoryId,
        innerKeySelector: product => product.CategoryId,
        resultSelector: (c, p) =>
        new { c.CategoryName, p.ProductName, p.ProductId })
            .OrderBy(cp => cp.CategoryName);

        foreach (var item in queryJoin)
        {
            WriteLine("{0}: {1} is in {2}.",
            arg0: item.ProductId,
            arg1: item.ProductName,
            arg2: item.CategoryName);
        }
    }
}

static void GroupJoinCategoriesAndProducts()
{
    using (Northwind db = new())
    {
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(
        inner: db.Products,
        outerKeySelector: category => category.CategoryId,
        innerKeySelector: product => product.CategoryId,
        resultSelector: (c, matchingProducts) => new
        {
            c.CategoryName,
            Products = matchingProducts.OrderBy(p => p.ProductName)
        });

        foreach (var category in queryGroup)
        {
            WriteLine("{0} has {1} products.",
            arg0: category.CategoryName,
            arg1: category.Products.Count());
            foreach (var product in category.Products)
            {
                WriteLine($" {product.ProductName}");
            }
        }
    }
}

static void AggreagteMethod()
{
    using (Northwind db = new())
    {
        WriteLine("{0,-25} {1,10}", arg0: "Product count:", arg1: db.Products.Count());

        WriteLine("{0,-25} {1,10:$#,##0.00}", arg0: "Highest product price:", arg1: db.Products.Max(p => p.UnitPrice));

        WriteLine("{0,-25} {1,10:N0}", arg0: "Sum of units in stock:", arg1: db.Products.Sum(p => p.UnitsInStock));

        WriteLine("{0,-25} {1,10:N0}", arg0: "Sum of units on order:",  arg1: db.Products.Sum(p => p.UnitsOnOrder));

        WriteLine("{0,-25} {1,10:$#,##0.00}", arg0: "Average unit price:", arg1: db.Products.Average(p => p.UnitPrice));

        WriteLine("{0,-25} {1,10:$#,##0.00}", arg0: "Value of units in stock:", arg1: db.Products.Sum(p => p.UnitPrice * p.UnitsInStock));
    }
}