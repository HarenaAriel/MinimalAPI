using System;
using System.Collections.Generic;
using ApiRFIDSys.Context;

namespace ApiRFIDSys.Models{
  public class Product{
    
    public Product(){}
    public Product(int id, string message){
      IDMessage = id;
      Message = message;
    }

    // Attribut de class

    public int IDMessage {get; set;}
    public string Message{get; set;}

  }
}
