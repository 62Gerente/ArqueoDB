using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Distrito
    {
        public int DistritoID { get; set; }

        [DisplayName("Nome do Distrito")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome do distrito necessário")]
        public string Nome { get; set; }

        [DisplayName("País")]
        public int PaisID { get; set; }
        public Pais Pais{ get; set; }
    }
}