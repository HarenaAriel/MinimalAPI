using System;
using System.Collections.Generic;
using ApiRFIDSys.Models;

namespace ApiRFIDSys.Data{

  public class ProductData{

    public ProductData(){ }

    public List<Product> AllProducts = new List<Product>(){
      new Product(1, "Product 1"),
      new Product(2, "Product 2"),
      new Product(3, "Product 3"),
    };

    // Get All product
    public List<Product> GetAllProducts(){
      return AllProducts;
    }

    // Get 1 Product
    public Product GetProduct(int id){
      return AllProducts.SingleOrDefault(x => x.IDMessage == id);
    }

    // Insert a new Product
    public Product CreateProduct(Product product){
      AllProducts.Add(product);
      return GetProduct(product.IDMessage);
    }

    // Edit an existing Product
    public Product EditProduct(Product product){
      var currentProduct = GetProduct(product.IDMessage);
      if(currentProduct.IDMessage == product.IDMessage){
        currentProduct.Message = product.Message;
      }
      return currentProduct;
    }
    
    // Delete an existing Product
    public void DeleteProduct(int id){
      AllProducts.Remove(GetProduct(id));
    }

  }

}