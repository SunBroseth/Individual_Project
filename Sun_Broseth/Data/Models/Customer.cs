using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sun_Broseth.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Char Sex { get; set; }
        public DateTime DOB { get; set; }
        public string POB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
