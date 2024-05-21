using Manero_WebApp.Models;

namespace Manero_WebApp.Services;

public class ProductService
{

    private List<Product> Products = new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Test 1",
            Sizes = new List<string> { "XS", "S", "M", "L", "XL", "XXL"},
            Color = new List<string> { "Red", "LightBlue", "Beige", "DarkBlue", "Black"},
            Rating = 4,
            Price = 799,
            Description = "Test 1"
        },
        new Product
        {
            Id = 2,
            Name = "Test 2",
            Sizes = new List<string> { "XS", "S", "M", "L", "XL", "XXL"},
            Color = new List<string> { "Red", "LightBlue", "Beige", "DarkBlue", "Black"},
            Rating = 5,
            Price = 1000,
            Description = "Test 2"
        }
    };

    private List<ProductEntity> AllProducts = new List<ProductEntity>
    {
        new ProductEntity
        {
            Id = "1",
            BatchNumber = "Batch001",
            Title = "T-shirt",
            ShortDescription = "Short Description t1",
            LongDescription = "Amet amet Lorem eu consectetur in deserunt nostrud dolor culpa ad sint amet. Nostrud deserunt consectetur culpa minim mollit veniam aliquip pariatur exercitation ullamco ea voluptate et. Pariatur ipsum mollit magna proident nisi ipsum.",
            Categories = new List<string> { "T-shirt", "Shirt"},
            Color = "LightBlue",
            Size = "M",
            Price = 799,
            ImageUrl = "/images/home/clothes-1.jpg"
        },
        new ProductEntity
        {
            Id = "2",
            BatchNumber = "Batch007",
            Title = "Chinos",
            ShortDescription = "Short Description t2",
            LongDescription = "Amet amet Lorem eu consectetur in deserunt nostrud dolor culpa ad sint amet. Nostrud deserunt consectetur culpa minim mollit veniam aliquip pariatur exercitation ullamco ea voluptate et. Pariatur ipsum mollit magna proident nisi ipsum.",
            Categories = new List<string> { "Pants", "Jeans"},
            Color = "DarkBlue",
            Size = "L",
            Price = 1799,
            ImageUrl = "/images/home/clothes-1.jpg"
        },

        new ProductEntity
        {
            Id = "3",
            BatchNumber = "Batch007",
            Title = "Chinos",
            ShortDescription = "Short Description t2",
            LongDescription = "Amet amet Lorem eu consectetur in deserunt nostrud dolor culpa ad sint amet. Nostrud deserunt consectetur culpa minim mollit veniam aliquip pariatur exercitation ullamco ea voluptate et. Pariatur ipsum mollit magna proident nisi ipsum.",
            Categories = new List<string> { "Pants", "Jeans"},
            Color = "Beige",
            Size = "M",
            Price = 1799,
            ImageUrl = "/images/home/clothes-1.jpg"
        },
        
        new ProductEntity
        {
            Id = "4",
            BatchNumber = "Batch007",
            Title = "Chinos",
            ShortDescription = "Short Description t2",
            LongDescription = "Amet amet Lorem eu consectetur in deserunt nostrud dolor culpa ad sint amet. Nostrud deserunt consectetur culpa minim mollit veniam aliquip pariatur exercitation ullamco ea voluptate et. Pariatur ipsum mollit magna proident nisi ipsum.",
            Categories = new List<string> { "Pants", "Jeans"},
            Color = "LightBlue",
            Size = "S",
            Price = 1799,
            ImageUrl = "/images/home/clothes-1.jpg"
        }
    };

    public Task<List<Product>> GetProductsAsync()
    {
        return Task.FromResult(Products);
    }
    public Task<Product?> GetProductByIdAsync(int productId)
    {
        var product = Products.FirstOrDefault(x => x.Id == productId);
        return Task.FromResult(product);
    }

    public Task<List<ProductEntity>> GetAllProductsAsync()
    {
        return Task.FromResult(AllProducts);
    }

    public Task<ProductEntity?> GetAllProductByIdAsync(string productId)
    {
        var product = AllProducts.FirstOrDefault(x => x.Id == productId);
        return Task.FromResult(product);
    }

    public Task<List<ProductEntity>> GetProductsBytTitleAndBatchAsync(string title, string batchNumber)
    {
        var products = AllProducts.Where(x => x.Title == title && x.BatchNumber == batchNumber).ToList();
        return Task.FromResult(products);
    }
}
