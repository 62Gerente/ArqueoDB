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
        public Comentario Comentario { get; set; }

        [DisplayName("Artefacto")]
        public int ArtefactoID { get; set; }
        public Artefacto Artefacto { get; set; }
    }
}