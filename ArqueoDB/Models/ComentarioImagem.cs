using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class ComentarioImagem
    {
        public int ComentarioImagemID { get; set; }

        [DisplayName("Comentário")]
        public int ComentarioID { get; set; }
        public virtual Comentario Comentario { get; set; }

        [DisplayName("Imagem")]
        public int ImagemID { get; set; }
        public virtual Imagem Imagem { get; set; }

    }
}