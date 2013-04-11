using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class OrganizacaoSeguida
    {
        public int OrganizacaoSeguidaID { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public virtual Utilizador Utilizador { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }
        public virtual Organizacao Organizacao { get; set; }

    }
}