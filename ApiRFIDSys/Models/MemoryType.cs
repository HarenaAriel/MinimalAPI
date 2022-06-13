using System;

namespace ApiRFIDSys.Models{

  public class MemoryType{

    public MemoryType(){}
    public MemoryType(int id, string memoryType){
      _id = id;
      _memoryType = memoryType;
    }

    public int _id {get; set;}
    public string _memoryType {get; set;}

  }

}