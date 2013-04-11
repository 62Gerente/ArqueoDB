using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class UtilizadorSeguido
    {
        public int UtilizadorSeguidoID { get; set; }

        [DisplayName("Utilizador Seguidor")]
        public int SeguidorID { get; set; }
        public virtual Utilizador Seguidor { get; set; }

        [DisplayName("Utilizador Seguido")]
        public int SeguidoID { get; set; }
        public virtual Utilizador Seguido { get; set; }

    }
}