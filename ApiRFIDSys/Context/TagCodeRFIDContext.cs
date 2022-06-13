using System;
using System.Collections.Generic;
using ApiRFIDSys.Models;
using MySql.Data.MySqlClient;

namespace ApiRFIDSys.Context{

    public class TagCodeRFIDContext{

    private MySqlConnection _connection = null;
    public TagCodeRFIDContext(MySqlConnection connection) 
    {
      _connection = connection;
    }

    /*
    * Only on a ReadOnly mode
    * There cannot be a modification in this table
    */

    public List<TagCodeRFID> GetAllTagCodeRFID(){
      try{
        List<TagCodeRFID> _allTagCodeRFID = new List<TagCodeRFID>();
        using (_connection)  
        {  
            _connection.Open();  
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM TAGCodeRFID", _connection);  
            using (var reader = cmd.ExecuteReader())  
            {  
                while (reader.Read())  
                {  
                    _allTagCodeRFID.Add(new TagCodeRFID()  
                    {  
                        _iD = Convert.ToInt32(reader["ID"]),  
                        _memoryType = Convert.ToInt32(reader["MemoryTypeID"]),
                        _memoryCode = reader["MemoryCode"].ToString()
                    });  
                }  
            }
            _connection.Dispose();
            _connection.Close();  
        }
        return _allTagCodeRFID;
      }
      catch(Exception e){
        Console.WriteLine(e.ToString());
        return null;
      }
    }

    public List<TagCodeRFID> GetAllOfMemoryTagCodeRFID(int memoryTypeId){
      try{
        List<TagCodeRFID> _allTagCodeRFID = new List<TagCodeRFID>();
        using (_connection)  
        {  
            _connection.Open();  
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM TAGCodeRFID WHERE MemoryTypeID = {memoryTypeId}", _connection);  
            using (var reader = cmd.ExecuteReader())  
            {  
                while (reader.Read())  
                {  
                    _allTagCodeRFID.Add(new TagCodeRFID()  
                    {  
                        _iD = Convert.ToInt32(reader["ID"]),  
                        _memoryType = Convert.ToInt32(reader["MemoryTypeID"]),
                        _memoryCode = reader["MemoryCode"].ToString()
                    });  
                }  
            }
            _connection.Dispose();
            _connection.Close();  
        }
        return _allTagCodeRFID;
      }
      catch(Exception e){
        Console.WriteLine(e.ToString());
        return null;
      }
    }

    public TagCodeRFID GetTagCodeRFIDByID(int id){
      try{
        TagCodeRFID _oneTagCodeRFID = new TagCodeRFID();
        using (_connection)  
        {  
            _connection.Open();  
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM TAGCodeRFID WHERE ID = {id}", _connection);  
            using (var reader = cmd.ExecuteReader())  
            {  
                while (reader.Read())  
                {  
                  _oneTagCodeRFID._iD = Convert.ToInt32(reader["ID"]); 
                  _oneTagCodeRFID._memoryType = Convert.ToInt32(reader["MemoryTypeID"]);
                  _oneTagCodeRFID._memoryCode = reader["MemoryCode"].ToString();
                }  
            }
            _connection.Dispose();
            _connection.Close();  
        }
        return _oneTagCodeRFID;
      }
      catch(Exception e){
        Console.WriteLine(e.ToString());
        return null;
      }
    }

  }

}