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
        public Publicacao Publicacao { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public Local Local { get; set; }

    }
}