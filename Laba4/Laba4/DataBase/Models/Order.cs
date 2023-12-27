using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<Customer>? Customers { get; set; }
        public string date_of_order { get; set; }
        public int car_id { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
