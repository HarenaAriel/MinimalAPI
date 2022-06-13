using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ApiRFIDSys.Context{

  public class DBConnection{

    public static string _connectionString = "server=localhost;port=3306;user=root;password=Harenariel15@;database=WorkingAdventure";
    public static MySqlConnection connectionToDB = null;

    public DBConnection(){}

    public static MySqlConnection GetConnection(){
      if(connectionToDB == null){
        connectionToDB = new MySqlConnection(_connectionString);
      }
      return connectionToDB;
    }

  }

}