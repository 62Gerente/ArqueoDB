using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Imagem
    {
        public int ImagemID { get; set; }

        [Required(ErrorMessage = "Necessário indicar nome da imagem")]
        [DisplayName("Nome da Imagem")]
        public string Nome { get; set; }

        [DisplayName("Directoria")]
        public int DirectoriaID { get; set; }
        public virtual Directoria Directoria { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataPublicacao { get; set; }
       
	    [Required(ErrorMessage = "Necessário indicar nível de acesso")]
        [DisplayName("Pública")]
        public bool Publica { get; set; }

        [ScaffoldColumn(false)]
        public bool Apagada{ get; set; }
    }
}
