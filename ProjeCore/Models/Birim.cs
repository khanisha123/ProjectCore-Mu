using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Models
{
    public class Birim
    {
        [Key]
        public int BrimId { get; set; }
        public string BrimAd { get; set; }

        public IList<Personel> Personels { get; set; }
    }
}
