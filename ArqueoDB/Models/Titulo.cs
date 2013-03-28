using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArqueoDB.Models
{
    public class Titulo
    {
        public int TituloID { set; get; }
        public string Nome { set; get; }
    }
}