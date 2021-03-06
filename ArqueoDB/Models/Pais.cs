﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Pais
    {
        public int PaisID { get; set; }

        [DisplayName("Nome do país")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome do país necessário")]
        public string Nome { get; set; }

        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}