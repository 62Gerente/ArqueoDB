using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Artefacto
    {
        public int ArtefactoID { get; set; }

        [DisplayName("Nome do Artefacto")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome do artefacto necessário")]
        public string Nome { get; set; }

        [StringLength(30, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Coordenadas necessárias")]
        public string Cordenadas { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Descrição do artefacto necessária")]
        public string Descricao { get; set; }

        [DisplayName("Data de Descoberta")]
        public DateTime DataDescoberta { get; set; }

        [DisplayName("Local")]
        public int LocalID { get; set; }
        public virtual Local Local { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }
        public virtual Organizacao Organizacao { get; set; }

        [DisplayName("Responsável pela Descoberta")]
        public int ResponsavelID { get; set; }
        [ForeignKey("ResponsavelID")]
        public virtual Profissional Responsavel { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagado { get; set; }

        [DisplayName("Público")]
        public bool Publico { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }
    }
}