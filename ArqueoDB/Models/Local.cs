using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Local
    {

        public int LocalID { get; set; }

        [DisplayName("Nome do Local")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome do local necessário")]
        public string Nome { get; set; }

        [DisplayName("Organização Responsável")]
        public int OrganizacaoID { get; set; }
        public Organizacao Organizacao { get; set; }

        [DisplayName("Profissional Responsável")]
        public int ResponsavelID { get; set; }
        public Profissional Responsavel { get; set; }

        [StringLength(30, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Coordenadas necessárias")]
        public string Coordenadas { get; set; }

        [DisplayName("Data de Registo")]
        public DateTime DataRegisto { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Distrito")]
        public int DistritoID { get; set; }
        public Distrito Distrito { get; set; }

        [Required(ErrorMessage = "Necessário indicar nível de acesso")]
        [DisplayName("Público")]
        public bool Publico { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagado { get; set; }
    }
}