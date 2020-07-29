using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;
using System.Linq;
using PizzaStore.Storing.Repository;

namespace PizzaStore.Client
{
  class Stores
  {
    public static void Menu()
    {
      bool exit = false;

      while (!exit)
      {
        do
        {

          Starter.MgmtMenu();

          int selection;

          int.TryParse(Console.ReadLine(), out selection);

          switch (selection)
          {
            case 1: // Sales History
              SalesHistory();
              break;
            case 2: // Order History
              OrderHistory();
              break;
            default:
              exit = true;
              continue;
          }

          System.Console.WriteLine();
          System.Console.WriteLine("Press any key to continue");
          System.Console.ReadKey();

        } while (!exit);

      }

    }

    static void SalesHistory()
    {
      var pizzaTypeId = 0;
      var exit = false;

      pizzaTypeId = GetPizzaSales(ref exit);

      // enter queries here
    }

    static void OrderHistory()
    {
      var historyType = 0;
      var exit = false;

      historyType = GetHistoryType(ref exit);

      // enter queries here
    }

    static int GetPizzaSales(ref bool exit)
    {
      var exit1 = false;
      var selection = 0;
      var typeSelected = 0;

      while (!exit && !exit1)
      {
        Starter.ChooseSalesPizza();

        int.TryParse(Console.ReadLine(), out selection);

        var repository = new PizzaRepository();
        var orderList = repository.ReadAll();      // reading all Pizzas for now

        switch (selection)
        {

          case 0:   // All types

            ShowHistory(orderList, selection);
            exit1 = true;
            break;
          case 1:   // Cheese

            exit1 = true;
            break;
          case 2:   // Peperroni

            exit1 = true;
            break;
          case 3:   // Hawaiian

            exit1 = true;
            break;
          case 4:   // Custom

            exit1 = true;
            break;
          default:
            continue;
        }
        // System.Console.WriteLine();
        // System.Console.WriteLine("Press any key to continue");
      }
      return typeSelected;
    }

    public static int GetHistoryType(ref bool exit)
    {
      //      bool exit = false;
      var exit1 = false;
      int selection = 0;

      while (!exit1)
      {
        do
        {

          int.TryParse(Console.ReadLine(), out selection);

          switch (selection)
          {
            case 1: // Order History by Store
                    // Prompt for Store Id

              exit1 = true;
              break;
            case 2: // Order History by User
                    // Prompt for User Id
              exit1 = true;
              break;
            default:
              exit = true;
              continue;
          }

          System.Console.WriteLine();
          System.Console.WriteLine("Press any key to continue");
          System.Console.ReadKey();

        } while (!exit1);

      }
      return selection;
    }
    static void ShowHistory(List<Pizza> results, int pizzaType)
    {
      System.Console.WriteLine("Summary of the Current Month's Sales");
      System.Console.WriteLine("as of");
      System.Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy"));
      System.Console.WriteLine();

      System.Console.WriteLine("Item No.  " + "Item Description                " + "Qty. " + "Price");
      System.Console.WriteLine("--------------------------------------------------------\n");

      var item = 1;
      var totalPrice = 0m;
      var totalQty = 0;
      var qty = 1;

      foreach (var o in results)
      {
        System.Console.WriteLine($"{item}  {o.Size}, {o.Crust} Crust, {o.Name} Pizza        {qty}  ${o.Price}");
        totalQty += qty;
        totalPrice += o.Price;
        item++;
      }

      System.Console.WriteLine("--------------------------------------------------------");
      System.Console.WriteLine($"TOTALS:                                  {totalQty}  ${totalPrice}");
    }
  }
}
