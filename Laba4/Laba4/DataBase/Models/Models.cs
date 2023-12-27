using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models
{
    public class Model
    {
        public int Id { get; set; }
        public string model_name { get; set; } = null!;
        public int mark_id { get; set; }
        public Mark mark { get; set; }
        public List<Car>? cars { get; set; }

    }
}
