using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArqueoDB.Models
{
    public class Utilizador
    {
        public int UtilizadorID { get; set; }

        [DisplayName("Nome de Utilizador")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome de utilizador necessário")]
        public string NomeUtilizador { get; set; }

        [Required(ErrorMessage = "Email necessário")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [RegularExpression(@".+@.+\.[a-z]+", ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password necessária")]       
        [DataType(DataType.Password)]
        [StringLength(30,ErrorMessage= "A password tem de ter entre 5 a 30 caracteres",MinimumLength = 5)]
        public string Password { get; set; }

        [DisplayName("Nome Completo")]
        [StringLength(100, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome completo necessário")]
        public string Nome { get; set; }

        [DisplayName("Distrito")]
        public int DistritoID { get; set; }
        public virtual Distrito Distrito { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Range(0,2)]
        public int Sexo { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Descricao { get; set; }

        [DisplayName("Telemóvel")]
        [StringLength(15, ErrorMessage = "Número máximo de caracteres excedido")]
        [RegularExpression(@"(\+?)[0-9]{9,}", ErrorMessage = "Formato inválido")]
        public string Telemovel { get; set; }

        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Facebook { get; set; }
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Google { get; set; }
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Twitter { get; set; }
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Linkedin { get; set; }

        [ScaffoldColumn(false)]
        public bool Banido { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagado { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataRegisto { get; set; }

        [DisplayName("Título")]
        public int TituloID { get; set; }
        public virtual Titulo Titulo { get; set; }

        [DisplayName("Imagem de Perfil")]
        public int ImagemPerfilID { get; set; }
        [ForeignKey("ImagemPerfilID")]
        public virtual Imagem ImagemPerfil { get; set; }

        [DisplayName("Imagem de Capa")]
        public int ImagemCapaID { get; set; }
        [ForeignKey("ImagemCapaID")]
        public virtual Imagem ImagemCapa { get; set; }


        public virtual ICollection<Badge> Badges { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<Feed> Feeds { get; set; }
        public virtual ICollection<Local> LocaisSeguidos { get; set; }
        public virtual ICollection<Mensagem> MensagensEnviadas { get; set; }
        public virtual ICollection<Mensagem> MensagensRecebidas { get; set; }
        public virtual ICollection<Organizacao> OrganizacoesSeguidas { get; set; }
        public virtual ICollection<Publicacao> Publicacoes { get; set; }
        public virtual ICollection<Utilizador> UtilizadoresSeguidos { get; set; }


    }
}