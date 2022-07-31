// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using BKModev.Models;

using Microsoft.AspNetCore.Mvc;

namespace BKModev.Controllers;
public class ProductController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(Product product)
    {
        var productList = MarketDatabase.ProductList;
        return View(productList);
    }
    public IActionResult List()
    {
        ProductCategoryModel model = new ProductCategoryModel();
        model.Categories = MarketDatabase.CategoryList;
        model.Products = MarketDatabase.ProductList;
        return View(model);
    }
    //CRUD
    //[HttpGet]
    //public IActionResult Create()
    //{
    //    return View(); 
    //}
    [HttpPost]
    public IActionResult Create(Product product)
    {
        //if (!ModelState.IsValid)
        var productControl = MarketDatabase.ProductList.FirstOrDefault(x => x.Name == product.Name);
        if (productControl == null)
        {
            MarketDatabase.Create(product);
            ViewBag.Mesaj = "Ürün ekleme başarılı.";
            return RedirectToAction("List");
        }
        else
        {
            ViewBag.Mesaj = "Bu ürün sistemde kayıtlıdır Lütfen yeni bir ürün adı ile ilerleyiniz";
        }
        return View();
    }
    public IActionResult Delete(int Id)
    {


        var product = MarketDatabase.ProductList.FirstOrDefault(x => x.Id == Id);
        MarketDatabase.Delete(product);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int Id)
    {
        var product=MarketDatabase.ProductList.FirstOrDefault(x => x.Id == Id);
        if (product==null)
        {
            return RedirectToAction("List");
        }
        else return View(product);

    }
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        MarketDatabase.Edit(product);
        var editProduct = MarketDatabase.ProductList.FirstOrDefault(x => x.Id == product.Id);
        //return View(editProduct);
        return View(Request.Headers["Referrer"].ToString());

    }
}
