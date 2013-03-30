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
        public Publicacao Publicacao { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }
        public Organizacao Organizacao { get; set; }

    }
}