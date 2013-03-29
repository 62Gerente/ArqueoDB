using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Directoria
    {
        public int DirectoriaID { get; set; }

        [StringLength(100, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Path necessário")]
        public string Path { get; set; }
    }
}