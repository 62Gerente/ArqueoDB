using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class ComentarioPublicacao
    {
        public int ComentarioPublicacaoID { get; set; }

        [DisplayName("Comentário")]
        public int ComentarioID { get; set; }
        public Comentario Comentario { get; set; }

        [DisplayName("Publicação")]
        public int PublicacaoID { get; set; }
        public Publicacao Publicacao { get; set; }
    }
}