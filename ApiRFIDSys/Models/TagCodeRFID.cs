using System;

namespace ApiRFIDSys.Models{

  public class TagCodeRFID{

    public TagCodeRFID(){}
    public TagCodeRFID(int id, int memoryType, string memoryCode){
      _iD = id;
      _memoryType = memoryType;
      _memoryCode = memoryCode;
    }

    public int _iD {get; set;}
    public int _memoryType {get; set;}
    public string _memoryCode {get; set;}

  }

}