using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string Ad { get; set; } 
        public string Soyad { get; set; } 
        public string Şehir { get; set; }
        
        public int BirimId { get; set; } 
        public Birim Birim { get; set; } 
    }
}
