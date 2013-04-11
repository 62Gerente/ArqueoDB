using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class PublicacaoLocal
    {
        public int PublicacaoLocalID { get; set; }

        [DisplayName("Publicação")]
        public int PublicacaoID { get; set; }
        public virtual Publicacao Publicacao { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public virtual Local Local { get; set; }

    }
}