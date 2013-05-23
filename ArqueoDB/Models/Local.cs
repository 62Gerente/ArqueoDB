using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual Organizacao Organizacao { get; set; }

        [DisplayName("Profissional Responsável")]
        public int ResponsavelID { get; set; }
        [ForeignKey("ResponsavelID")]
        public virtual Profissional Responsavel { get; set; }

        [StringLength(30, ErrorMessage = "Número máximo de caracteres excedido")]
   
        public string Coordenadas { get; set; }

        [DisplayName("Data de Registo")]
        public DateTime DataRegisto { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Descricao { get; set; }

        [DisplayName("Distrito")]
        public int DistritoID { get; set; }
        public virtual Distrito Distrito { get; set; }

        [Required(ErrorMessage = "Necessário indicar nível de acesso")]
        [DisplayName("Público")]
        public bool Publico { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagado { get; set; }

        public virtual ICollection<Artefacto> Artefactos { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }
        public virtual ICollection<Publicacao> Publicacoes { get; set; }
        public virtual ICollection<Planta> Plantas { get; set; }
        public virtual ICollection<Documento> Documentos { get; set; }
        public virtual ICollection<Utilizador> Seguidores { get; set; } 
    }
}