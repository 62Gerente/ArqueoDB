using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Administrador
    {
        public int AdministradorID { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}