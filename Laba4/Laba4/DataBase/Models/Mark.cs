using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Mark
    {
        public int ID { get; set; }
        public string mark_name { get; set; } = null!;
        public List<Model>? Models { get; set; }
    }
}
