using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Personalnumber
    {
        public Guid ID { get; set; }
        
        public string number { get; set; } = null!;
        public Customer Customer { get; set; } // Свойство навигации
    }
}
