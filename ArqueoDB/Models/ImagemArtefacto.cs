using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class ImagemArtefacto
    {
        public int ImagemArtefactoID { get; set; }

        [DisplayName("Imagem")]
        public int ImagemID { get; set; }
        public Imagem Imagem { get; set; }

        [DisplayName("Artefacto")]
        public int ArtefactoID { get; set; }
        public Artefacto Artefacto { get; set; }

    }
}