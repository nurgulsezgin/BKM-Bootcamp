// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace BKModev.Models;

public class MarketDatabase
{
    private static List<Category> _categoryList;
    private static List<Product> _productList;

    static MarketDatabase()
    {
        _categoryList = new List<Category>()
        {
            new Category{Id=1, CategoryName="Snacks"},
            new Category{Id=2, CategoryName="Electronic"},
            new Category{Id=3, CategoryName="Vegetables and fruit"},
            new Category{Id=4, CategoryName="Freezer"},
            new Category{Id=5, CategoryName="Care Products"},

        };
        _productList = new List<Product>()
        {
            new Product{Id=1,Name="BlueBerry", Price=10.99, CategoryId=3},
            new Product{Id=2,Name="Cable", Price=10.99, CategoryId=2},
            new Product{Id=3,Name="Fish", Price=10.99, CategoryId=4},
            new Product{Id=4,Name="Cips", Price=10.99, CategoryId=1},
            new Product{Id=5,Name="Ice-Cream", Price=10.99, CategoryId=4},
            new Product{Id=6,Name="Moisturizer", Price=10.99, CategoryId=5},
            new Product{Id=7,Name="Onion", Price=10.99, CategoryId=2},
            new Product{Id=8,Name="Cracker", Price=10.99, CategoryId=1},
            new Product{Id=8,Name="Biscuit", Price=10.99, CategoryId=1}

        };
    }
    public static List<Category> CategoryList
    {
        get { return _categoryList; }
    }
    public static List<Product> ProductList
    {
        get { return _productList; }
    }

    //METHODS
    public static void Create(Product product)
    {
        _productList.Add(product);
    }
    public static void Delete(Product product)
    {
        _productList.Remove(product);
    }
    public static void Edit(Product product)
    {
        var productEdit = _productList.FirstOrDefault(x => x.Id == product.Id);

        productEdit.Name=product.Name;
        productEdit.Price=product.Price;
        productEdit.Category=product.Category;
    }
}
