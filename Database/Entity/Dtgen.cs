using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpBeginner.Database.Entity
{
    public class Dtgen
    {
    
        public int? genId { get; set; }
        public string genUserId { get; set; }
        public string genPassword { get; set; }
        public string genCreateAt { get; set; }
        public string genUpdateAt { get; set; }
    }
}
