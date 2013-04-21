using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArqueoDB.Models
{
    public class Titulo
    {
        public int TituloID { set; get; }
        [Required(ErrorMessage = "Título necessário")]
        [DisplayName("Título")]
        [StringLength(30, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Nome { set; get; }

//        public virtual ICollection<Utilizador> Utilizadores { get; set; }
    }

}