﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Organizacao
    {
        public int OrganizacaoID { get; set; }
        
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome de organização necessário")]
        public string Nome { get; set; }

        [StringLength(30, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Coordenadas necessárias")]
        public string Coordenadas { get; set; }

        [StringLength(500, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Morada { get; set; }

        [DisplayName("Distrito")]
        public int DistritoID { get; set; }
        public Distrito Distrito { get; set; }

        [DisplayName("Profissional Responsável")]
        public int ResponsavelID { get; set; }
        public Profissional Responsavel { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Descricao { get; set; }

        [DisplayName("Data de Fundação")]
        public DateTime DataFundacao { get; set; }

        [StringLength(15, ErrorMessage = "Número máximo de caracteres excedido")]
        [RegularExpression(@"(\+?)[0-9]{9,}", ErrorMessage = "Formato inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Email necessário")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [RegularExpression(@".+@.+\.[a-z]+", ErrorMessage = "Email inválido")]
        public string Email { get; set; }
       
        [StringLength(15, ErrorMessage = "Número máximo de caracteres excedido")]
        [RegularExpression(@"(\+?)[0-9]{9,}", ErrorMessage = "Formato inválido")]
        public string Fax { get; set; }

        [DisplayName("Imagem de Perfil")]
        public int ImagemPerfilID { get; set; }
        public Imagem ImagemPerfil { get; set; }

        [DisplayName("Imagem de Capa")]
        public int ImagemCapaID { get; set; }
        public Imagem ImagemCapa { get; set; }

        [Required(ErrorMessage = "Necessário indicar nível de acesso")]
        [DisplayName("Pública")]
        public bool Publica { get; set; }
        
        [ScaffoldColumn(false)]
        public bool Activa { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagada { get; set; }
    }
}