using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Texto { get; set; }

        public virtual Utilizador Utilizador { get; set; }

        [DisplayName("Autor")]
        public int AutorID { get; set; }
        [ForeignKey("AutorID")]
        public virtual Utilizador Autor { get; set; }

        [DisplayName("Data de Publicação")]
        public DateTime DataPublicacao { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagado { get; set; }
    }
}