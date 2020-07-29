using System;
using System.Collections.Generic;

namespace PizzaStore.Storing
{
    public partial class Stores
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime DateModified { get; set; }
        public bool? Active { get; set; }
    }
}
