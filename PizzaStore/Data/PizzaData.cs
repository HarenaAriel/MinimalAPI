using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using PizzaStore.Models;

namespace PizzaStore.Data{
    public class PizzaData{

        public PizzaData(){

        }

        /* Preparation of data */

        public List<Pizza> listData = new List<Pizza>(){
            new Pizza(1, "Name 1", "Description 1"),
            new Pizza(2, "Name 2", "Description 2"),
            new Pizza(3, "Name 3", "Description 3"),
            new Pizza(4, "Name 4", "Description 4"),
            new Pizza(5, "Name 5", "Description 5"),
        };

        /* All CRUD functions needed for the sake of the application */

        /*
        Ariel
        06/05/2022
        Get all the Pizza in DB;
        return a list of pizza
        */
        public List<Pizza> GetPizzas(){
            return listData;
        }

        /*
        Ariel
        06/05/2022
        Get 1 the Pizza in DB by the Id;
        return 1 pizza and have 1 argument
        */
        public Pizza GetPizza(int id){
            return listData.SingleOrDefault(c => c.id == id);
        }

        /*
        Ariel
        06/05/2022
        Add 1 the Pizza in DB;
        */
        public Pizza AddPizza(Pizza pizza){
            listData.Add(pizza);
            return GetPizza(pizza.id);
        }

        /*
        Ariel
        06/05/2022
        Update 1 the Pizza in DB;
        */
        public Pizza UpdatePizza(int id, Pizza pizza){
            var pizzaToUpdate = GetPizza(id);
            if(pizzaToUpdate != null){
                pizzaToUpdate.name = pizza.name;
                pizzaToUpdate.description = pizza.description;
            }
            return GetPizza(pizzaToUpdate.id);
        }

        /*
        Ariel
        06/05/2022
        Delete a Pizza in DB;
        */
        public void DeletePizza(int id){
            var pizzaToDelete = GetPizza(id);
            listData.Remove(pizzaToDelete);
        }

    }
}