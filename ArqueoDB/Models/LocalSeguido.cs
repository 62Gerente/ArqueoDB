using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class LocalSeguido
    {
        public int LocalSeguidoID { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public Utilizador Utilizador { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public Local Local { get; set; }
    }
}