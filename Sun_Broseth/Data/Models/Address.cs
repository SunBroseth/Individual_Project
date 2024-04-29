using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun_Broseth.Data.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int CustomerId { get; set; }
        public string AddressName { get; set; }
    }
}
