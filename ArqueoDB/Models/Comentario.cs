using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Comentario
    {
        public int ComentarioID { get; set; }

        [DisplayName("Comentário")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Comentário necessário")]
        public string Comentario { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public Utilizador Utilizador { get; set; }

        [DisplayName("Data de Publicação")]
        public DateTime DataPublicacao { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagado { get; set; }
    }
}