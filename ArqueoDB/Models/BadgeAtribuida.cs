using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class BadgeAtribuida
    {
        public int BadgeAtribuidaID { get; set; }

        [DisplayName("Badge")]
        public int BadgeID { get; set; }
        public Badge Badge { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public Utilizador Utilizador { get; set; }

        [DisplayName("Data da Atribuição")]
        public DateTime DataAtribuicao { get; set; }
    }
}