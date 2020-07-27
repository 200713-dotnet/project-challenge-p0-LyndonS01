using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
  class Client
  {
    public static void Menu(Order cart)
    {
      bool exit = false;

      while (!exit)
      {
        List<string> toppings = new List<string>();

        string pizzaType = GetPizzaType(cart, toppings, ref exit);

        var pizzaSize = "";
        var pizzaCrust = "";
        var toppings_list = "";
        if (pizzaType != "")
        {
          pizzaSize = GetPizzaSize(cart, ref exit);                     // Ask for the size of pizza
          pizzaCrust = GetPizzaCrust(cart, ref exit);                   // Ask for the desired crust type
          toppings_list = String.Join(", ", toppings.ToArray());
          System.Console.WriteLine($"Pizza type is {pizzaType}, size = {pizzaSize}, toppings = {toppings_list}");

          cart.CreatePizza(pizzaSize, pizzaCrust, toppings);   // add the pizza to the order

          System.Console.WriteLine($"We added a {pizzaSize}, {pizzaCrust}, {pizzaType} pizza to your order.\n");
        }

      }

      static void DisplayCart(Order cart)
      {
        foreach (var pizza in cart.Pizzas)
        {
          System.Console.WriteLine(pizza);
        }

        System.Console.WriteLine("Press any key to continue.");
        System.Console.ReadKey();

      }

      static string GetPizzaType(Order cart, List<string> toppings, ref bool exit)
      {
        var exit1 = false;
        string typeSelected = "";

        // define available Pizza Types
        var pizzaTypes = new string[] { "Cheese", "Pepperoni", "Hawaiian", "Custom" };

        // define standard stopping sets for the above Pizza Types
        Dictionary<string, List<string>> ts = new Dictionary<string, List<string>>();
        ts.Add("Cheese", new List<string> { "cheese" });
        ts.Add("Pepperoni", new List<string> { "cheese", "pepperoni" });
        ts.Add("Hawaiian", new List<string> { "cheese", "ham", "pineapple" });
        ts.Add("Custom", new List<string> { "" });

        do
        {

          Starter.PrintMenu();

          int selection;

          int.TryParse(Console.ReadLine(), out selection);

          switch (selection)
          {
            case 1: // Cheese
              toppings.AddRange(ts["Cheese"]);
              typeSelected = pizzaTypes[selection - 1];
              System.Console.WriteLine($"You chose {typeSelected}");
              break;
            case 2: // Pepperoni
              toppings.AddRange(ts["Pepperoni"]);
              typeSelected = pizzaTypes[selection - 1];
              System.Console.WriteLine($"You chose {typeSelected}");
              break;
            case 3: // Hawaiian
              toppings.AddRange(ts["Hawaiian"]);
              typeSelected = pizzaTypes[selection - 1];
              System.Console.WriteLine($"You chose {typeSelected}");
              break;
            case 4: // Custom
                    //              toppings.AddRange(ts["Custom"]);
              AddCustomToppings(toppings);
              typeSelected = pizzaTypes[selection - 1];
              var toppings_list = "";
              toppings_list = String.Join(", ", toppings.ToArray());
              System.Console.WriteLine($"You chose {typeSelected} with {toppings_list}.");
              break;
            case 5:
              DisplayCart(cart);
              continue;
            case 6:
              var fmw = new FileManager();
              fmw.Write(cart);
              System.Console.WriteLine("Thank you for your order. Goodbye!");
              exit = true;
              break;
            case 7:
              var fmr = new FileManager();
              DisplayCart(fmr.Read());
              break;
            case 8:
              exit = true;
              break;
      default:
              break;
    }

    System.Console.WriteLine();
          exit1 = true;

        } while (!exit1);

        return typeSelected;
      }

static string GetPizzaSize(Order cart, ref bool exit)
{
  var exit1 = false;
  var selection = 0;
  var sizeSelected = "";

  while (!exit && !exit1)
  {
    Starter.ChooseSize();

    int.TryParse(Console.ReadLine(), out selection);

    switch (selection)
    {
      case 1:
        sizeSelected = "Family";
        System.Console.WriteLine($"You chose {sizeSelected}");
        exit1 = true;
        break;
      case 2:
        sizeSelected = "Large";
        System.Console.WriteLine($"You chose {sizeSelected}");
        exit1 = true;
        break;
      case 3:
        sizeSelected = "Regular";
        System.Console.WriteLine($"You chose {sizeSelected}");
        exit1 = true;
        break;
      default:
        continue;
    }

  }
  return sizeSelected;
}

static string GetPizzaCrust(Order cart, ref bool exit)
{
  var exit1 = false;
  var selection = 0;
  var crustSelected = "";

  while (!exit && !exit1)
  {
    Starter.ChooseCrust();

    int.TryParse(Console.ReadLine(), out selection);

    switch (selection)
    {
      case 1:
        crustSelected = "Thin";
        System.Console.WriteLine($"You chose {crustSelected}");
        exit1 = true;
        break;
      case 2:
        crustSelected = "Thick";
        System.Console.WriteLine($"You chose {crustSelected}");
        exit1 = true;
        break;
      case 3:
        crustSelected = "Stuffed";
        System.Console.WriteLine($"You chose {crustSelected}");
        exit1 = true;
        break;
      default:
        continue;
    }

  }
  return crustSelected;
}

static void AddCustomToppings(List<string> toppings)
{
  // define available toppings 
  var toppingTypes = new List<string> { "cheese", "cheese (extra)", "pepperoni", "sausage", "bell peppers", "ham", "pineapple", "bacon", "mushrooms" };
  var exit = false;
  var top_max = 5;
  var top_min = 2;
  var top_count = 0;

  do
  {
    var chosen_topping = "";
    chosen_topping = ShowAvailableToppings(toppingTypes, ref exit);
    if (chosen_topping != "")
    {
      toppings.Add(chosen_topping);
      toppingTypes.Remove(chosen_topping);
      top_count++;

      var toppings_list = String.Join(", ", toppings.ToArray());
      System.Console.WriteLine($"You chose {toppings_list} topping(s).\n");
    }
    else
    {
      if (top_count == top_min - 1)
      {
        System.Console.WriteLine("A minimum of two toppings is required for custom pizzas.\n");
        System.Console.WriteLine("Press any key to continue.\n");
        System.Console.ReadKey();
      }
    }

    if (top_count == top_max)
    {
      System.Console.WriteLine("You have added the maximum number of toppings.\n");
      System.Console.WriteLine("Press any key to return to the previous menu.\n");
      exit = true;
    }

  } while (!exit);
}

static string ShowAvailableToppings(List<string> top_choices, ref bool exit)
{
  var i = 1;
  var selection = 0;
  var exit1 = false;
  var chosen_topping = "";

  do
  {
    System.Console.WriteLine("Choose your toppings");
    System.Console.WriteLine();

    foreach (var t in top_choices)
    {
      System.Console.WriteLine($"Select {i} for {t}");
      i++;
    }
    System.Console.WriteLine("Press any other key if you are done adding toppings.");

    System.Console.WriteLine();
    int.TryParse(Console.ReadLine(), out selection);

    if (selection < 1 || selection > top_choices.Count)
    {
      exit1 = true;
      exit = true;
      continue;
    }
    string[] temp = top_choices.ToArray();
    chosen_topping = temp[selection - 1];
    exit1 = true;

  } while (!exit1);
  return chosen_topping;
}

    }
  }
}
