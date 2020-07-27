using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

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

        switch (selection)
        {
          case 0:   // All type

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
  }
}
