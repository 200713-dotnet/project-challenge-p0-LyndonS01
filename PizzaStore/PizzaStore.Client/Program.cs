using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
  class Program
  {
    static void Main()
    {
      Welcome();
    }

    static void Welcome()
    {
      System.Console.WriteLine("Welcome to PizzaWorld");
      System.Console.WriteLine("Best Pizza in the World");
      System.Console.WriteLine();

      System.Console.WriteLine("Select 1 for Client Orders");
      System.Console.WriteLine("Select 2 for Store Management");
      System.Console.WriteLine("Press any other key to exit");
      System.Console.WriteLine();

      int selection;
      int.TryParse(Console.ReadLine(), out selection);

      switch (selection)
      {
        case 1:
          var starter = new Starter();
          var user = new User();
          var store = new Store();

          try
          {
            Client.Menu(starter.CreateOrder(user, store));
          }
          catch (Exception ex)
          {
            System.Console.WriteLine(ex.Message);
          }

          break;
        case 2:
          try
          {
            Stores.Menu();
          }
          catch (Exception ex)
          {
            System.Console.WriteLine(ex.Message);
          }

          break;
        default:
          break;
      }

    }
  }
}
