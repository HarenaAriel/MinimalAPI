using System;
using System.Text;
using System.Collections.Generic;

namespace PizzaStore.Models{
    [System.Serializable]
    public class Pizza{

        public Pizza(int id, string? name, string? desc){
            this.id = id;
            this.name = name;
            this.description = desc;
        }

        public Pizza(){ }

        public int id{get; set;}
        public string? name{get; set;}
        public string? description{get; set;}

    }
}
