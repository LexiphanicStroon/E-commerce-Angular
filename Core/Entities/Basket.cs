using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Basket
    {
        public string Id { get; set; }
        public string BasketData { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}