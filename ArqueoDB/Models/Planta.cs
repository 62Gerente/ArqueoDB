using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Planta
    {
        public int PlantaID { get; set; }

        [DisplayName("Nome da Planta")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome da planta necessário")]
        public string Nome { get; set; }

        //[DisplayName("Local")]
        //public int LocalID { get; set; }
        //public virtual Local Local { get; set; }

        [DisplayName("Imagem")]
        public int ImagemID { get; set; }
        public virtual Imagem Imagem { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }
        public virtual Organizacao Organizacao { get; set; }

        [DisplayName("Profissional Responsável")]
        public int ResponsavelID { get; set; }
        [ForeignKey("ResponsavelID")]
        public virtual Profissional Responsavel { get; set; }

        [DisplayName("Data de Publicação")]
        public DateTime DataPublicacao { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Descricao { get; set; }

        [DisplayName("Público")]
        public bool Publico { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagado { get; set; }

    }
}