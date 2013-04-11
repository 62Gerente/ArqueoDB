using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class PublicacaoOrganizacao
    {
        public int PublicacaoOrganizacaoID { get; set; }

        [DisplayName("Publicação")]
        public int PublicacaoID { get; set; }
        public virtual Publicacao Publicacao { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }
        public virtual Organizacao Organizacao { get; set; }

    }
}