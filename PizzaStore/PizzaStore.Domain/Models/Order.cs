using System.Collections.Generic;
// using PizzaStore.Storing;
// using System.Linq;

// using domain = PizzaStore.Storing.Repositories.PizzaRepository;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    public string Store { get; set; }
    public string User { get; set; }
    public List<Pizza> Pizzas { get; }

    public void CreatePizza(string name, string size, string crust, List<string> toppings, decimal price)
    {
      
      Pizzas.Add(new Pizza(name, size, crust, toppings, price));
    }

    public Order()
    {
      Store = "Location A";
      User = "lyndons";
      Pizzas = new List<Pizza>();
    }
  }
}