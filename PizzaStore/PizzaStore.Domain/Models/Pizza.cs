using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    // STATE
    //fields
    // private readonly string _imageUrl = "https://some-url";
    // private const double _diameter = 0;
    private Dictionary<string, double> Sizes = new Dictionary<string, double>(); //Size and corresponding diameter in inches

    private List<string> _toppings = new List<string>();


    // private string _size;

    //properties
    public string Size { get; set; }
    public string Crust { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public const double _sizeFamily = 16.0;
    public const double _sizeLarge = 12.0;
    public const double _sizeRegular = 10.0;
    public double Diameter { get; set; } // in inches
    public List<string> Toppings
    {
      get
      {
        return _toppings; // backing field
      }
      set
      {
        
      }
    }

    // BEHAVIOR
    //constructors
    public Pizza(string name, string size, string crust, List<string> toppings, decimal price)
    {
      Name = name;
      Sizes.Add("Regular", _sizeRegular);
      Sizes.Add("Large", _sizeLarge);
      Sizes.Add("Family", _sizeFamily);
      Size = size;
      Diameter = Sizes[size];
      Crust = crust;
      Toppings.AddRange(toppings);
      Price = price;
    }

    public Pizza()
    {
      Size = "";
      Crust = "";
      Diameter = 0.0;
      // intentionally empty
    }

    //methods
    void AddToppings(string topping)
    {
      Toppings.Add(topping);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      var j = Toppings.Count;

      for (var i = Toppings.Count - 1; i >= 0; i--)
      {
        if (i > 0)
        {
          sb.Append(Toppings[i] + ", ");
        }
        else
        {
          if (j == 1)
          {
            sb.Append(Toppings[i]);
          }
          else
          {
            sb.Append("and " + Toppings[i]);
          }
        }

      }

      // foreach (var t in Toppings)
      // {
      //   sb.Append(t + ", ");
      // }

      return $"{Size} ({Diameter} in.), {Name}, {Crust}, {Name} Pizza. Toppings incl.: {sb}";
      // return $"{Size}, {Crust}, Pizza. Toppings incl.: {sb}";
    }

    //finalizers or destructors
  }
}
