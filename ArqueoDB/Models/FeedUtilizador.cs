using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class FeedUtilizador
    {
        public int FeedUtilizadorID { get; set; }

        [DisplayName("Feed")]
        public int FeedID { get; set; }
        public Feed Feed { get; set; }

        [DisplayName("Utilizador")]
        public int UtilizadorID { get; set; }
        public Utilizador Utilizador { get; set; }

    }
}