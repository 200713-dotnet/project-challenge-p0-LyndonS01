using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class PizzaTopping
    {
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
