using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Car
    {
        public int ID { get; set; }
        public int model_id { get; set; }
        public Model model { get; set; } = null!;
        public string year { get; set; } = null!;
        public string body_type { get; set; } = null!;
        public double engine_volume { get; set; }
        public double mileage { get; set; }
        public double price { get; set; }
        public int Order_id { get; set; }
        public List<Order>? OrdersCar { get; set; }
    }
}
