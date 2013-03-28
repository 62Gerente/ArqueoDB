using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArqueoDB.Models
{
    [Bind(Exclude = "TituloID")]
    public class Titulo
    {
        [ScaffoldColumn(false)]
        public int TituloID { set; get; }
        public string Nome { set; get; }
    }
}