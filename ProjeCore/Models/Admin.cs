using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        public string Kullanıcı { get; set; }
        [Required]
        public string Şifre { get; set; }       
    }
}
