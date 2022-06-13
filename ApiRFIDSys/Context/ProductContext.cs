using System;
using System.Collections.Generic;
using ApiRFIDSys.Models;
using MySql.Data.MySqlClient;

namespace ApiRFIDSys.Context{

  public class ProductContext{

    private MySqlConnection _connection;

    public ProductContext(MySqlConnection connect){
      _connection = connect;
    }

    // Get Data in Product Table of DB -- READ

    public List<Product> GetAllProductFromDB(){
      List<Product> products = new List<Product>();

      using (MySqlConnection _connect = _connection)  
      {  
          _connect.Open();  
          MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", _connect);  
    
          using (var reader = cmd.ExecuteReader())  
          {  
              while (reader.Read())  
              {  
                  products.Add(new Product()  
                  {  
                      IDMessage = Convert.ToInt32(reader["IDMessage"]),  
                      Message = reader["Message"].ToString()
                  });  
              }  
          }
          _connect.Dispose();
          _connect.Close();  
      }  

      return products;
    }

    public Product GetProductByIDFromDB(int id){
      Product products = new Product();

      using (MySqlConnection _connect = _connection)  
      {  
          _connect.Open();  
          MySqlCommand cmd = new MySqlCommand($"SELECT * FROM product WHERE IDMessage = {id}", _connect);  
    
          using (var reader = cmd.ExecuteReader())  
          {  
              while (reader.Read())  
              {  
                products.IDMessage = Convert.ToInt32(reader["IDMessage"]);  
                products.Message = reader["Message"].ToString();
              }  
          }
          _connect.Dispose();
          _connect.Close();  
      }  

      return products;
    }

    public Product GetProductFromDB(string message){
      Product products = new Product();

      using (MySqlConnection _connect = _connection)  
      {  
          _connect.Open();  
          MySqlCommand cmd = new MySqlCommand($"SELECT * FROM product WHERE Message = '{message}'", _connect);  
    
          using (var reader = cmd.ExecuteReader())  
          {  
              while (reader.Read())  
              {  
                products.IDMessage = Convert.ToInt32(reader["IDMessage"]);  
                products.Message = reader["Message"].ToString();
              }  
          }
          _connect.Dispose();
          _connect.Close();  
      }  

      return products;
    }

    // Interacts with Database for data manipulation - POST

    public void CreateNewProductToDB(Product product){
      using (MySqlConnection _connect = _connection)  
      {  
          _connect.Open();  
          MySqlCommand cmd = new MySqlCommand($"INSERT INTO Product(Message) VALUES('{product.Message}')", _connect);  
    
          using (var reader = cmd.ExecuteReader())  
          {  
              while (reader.Read())  
              {  
              }  
          }
          _connect.Dispose();
          _connect.Close();  
      }  
    }

    // Interacts with Database for data manipulation - PUT

    public void EditProductToDB(Product product){
      using (MySqlConnection _connect = _connection)  
      {  
          _connect.Open();  
          MySqlCommand cmd = new MySqlCommand($"UPDATE Product SET Message = '{product.Message}' WHERE IDMessage = {product.IDMessage}", _connect);  
    
          using (var reader = cmd.ExecuteReader())  
          {  
              while (reader.Read())  
              {  
              }  
          }
          _connect.Dispose();
          _connect.Close();  
      }  
    }

    // Interacts with Database for data manipulation - PUT

    public void DeleteProductToDB(int id){
      using (MySqlConnection _connect = _connection)  
      {  
          _connect.Open();  
          MySqlCommand cmd = new MySqlCommand($"DELETE FROM Product WHERE IDMessage = {id}", _connect);  
          using (var reader = cmd.ExecuteReader())  
          {  
              while (reader.Read())  
              {  
              }  
          }
          _connect.Dispose();
          _connect.Close();  
      }  
    }
  }

}