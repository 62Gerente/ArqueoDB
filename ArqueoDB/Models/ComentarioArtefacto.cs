using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class ComentarioArtefacto
    {
        public int ComentarioArtefactoID { get; set; }

        [DisplayName("Comentário")]
        public int ComentarioID { get; set; }
        public virtual Comentario Comentario { get; set; }

        [DisplayName("Artefacto")]
        public int ArtefactoID { get; set; }
        public virtual Artefacto Artefacto { get; set; }
    }
}