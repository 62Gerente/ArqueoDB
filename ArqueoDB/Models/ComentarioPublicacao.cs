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
        public virtual Comentario Comentario { get; set; }

        [DisplayName("Publicação")]
        public int PublicacaoID { get; set; }
        public virtual Publicacao Publicacao { get; set; }
    }
}