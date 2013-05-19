using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Profissional
    {
        public int ProfissionalID { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public virtual Utilizador Utilizador { get; set; }

        public virtual ICollection<Artefacto> Artefactos { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }
        public virtual ICollection<Organizacao> Organizacoes { get; set; }
    }
}