using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class MembroOrganizacao
    {
        public int MembroOrganizacaoID { get; set; }

        [DisplayName("Profissional")]
        public int ProfissionalID { get; set; }
        public virtual Profissional Profissional { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }
        public virtual Organizacao Organizacao { get; set; }

    }
}