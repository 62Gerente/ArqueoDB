using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Documento
    {
        public int DocumentoID { get; set; }

        [DisplayName("Título do Documento")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Título do documento necessário")]
        public string Titulo { get; set; }

        [DisplayName("Directoria")]
        public int DirectoriaID { get; set; }
        public virtual Directoria Directoria { get; set; }

        [DisplayName("Profissional Responsável")]
        public int ResponsavelID { get; set; }
        [ForeignKey("ResponsavelID")]
        public virtual Profissional Responsavel { get; set; }

        [DisplayName("Organização")]
        public int OrganizacaoID { get; set; }
        public virtual  Organizacao Organizacao { get; set; }

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