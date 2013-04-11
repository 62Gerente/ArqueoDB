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
        public virtual Imagem Imagem { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public virtual Local Local { get; set; }

    }
}