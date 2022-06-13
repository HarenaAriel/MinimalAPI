using System;
using System.Collections.Generic;
using ApiRFIDSys.Models;
using MySql.Data.MySqlClient;

namespace ApiRFIDSys.Context{

  public class MemoryTypeContext{

    private MySqlConnection _connection = null;
    public MemoryTypeContext(MySqlConnection connection) 
    {
      _connection = connection;
    }

    /*
    * Only on a ReadOnly mode
    * There cannot be a modification in this table
    */

    public List<MemoryType> GetAllMemoryTypes(){
      try{
        List<MemoryType> allmemoriestype = new List<MemoryType>();
        using (_connection)  
        {  
            _connection.Open();  
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM MemoryType", _connection);  
      
            using (var reader = cmd.ExecuteReader())  
            {  
                while (reader.Read())  
                {  
                    allmemoriestype.Add(new MemoryType()  
                    {  
                        _id = Convert.ToInt32(reader["ID"]),  
                        _memoryType = reader["MemoryType"].ToString()
                    });  
                }  
            }
            _connection.Dispose();
            _connection.Close();  
        }  
        return allmemoriestype;
      }
      catch(Exception e){
        Console.WriteLine(e.ToString());
        return null;
      }
    }

    public MemoryType GetMemoryTypesByID(int id){
      try{
        MemoryType memorytype = new MemoryType();
        using (_connection)  
        {  
            _connection.Open();  
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM MemoryType WHERE ID = {id}", _connection);  
      
            using (var reader = cmd.ExecuteReader())  
            {  
                while (reader.Read())  
                {  
                  memorytype._id = Convert.ToInt32(reader["ID"]);
                  memorytype._memoryType = reader["MemoryType"].ToString();
                }  
            }
            _connection.Dispose();
            _connection.Close();  
        }
        return memorytype;
      }
      catch(Exception e){
        Console.WriteLine(e.ToString());
        return null;
      }
    }

  }
  
}