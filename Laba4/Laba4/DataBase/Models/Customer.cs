using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string first_Name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public Guid PersonalnumberId { get; set; } // Внешний ключ
        public Personalnumber Personalnumber { get; set; } = null!; // Свойство навигации
        public int order_id;
        public List<Order>? OrdersCustomer { get; set; }
    }
}
