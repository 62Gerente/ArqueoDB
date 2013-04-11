using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class PublicacaoUtilizador
    {
        public int PublicacaoUtilizadorID { get; set; }

        [DisplayName("Publicação")]
        public int PublicacaoID { get; set; }
        public virtual Publicacao Publicacao { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public virtual Utilizador Utilizador { get; set; }

    }
}