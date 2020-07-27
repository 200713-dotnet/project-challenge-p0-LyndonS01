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

    }

    static void OrderHistory()
    {

    }
  }
}
