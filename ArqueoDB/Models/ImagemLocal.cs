using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class ImagemLocal
    {
        public int ImagemLocalID { get; set; }

        [DisplayName("Imagem")]
        public int ImagemID { get; set; }
        public Imagem Imagem { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public Local Local { get; set; }

    }
}