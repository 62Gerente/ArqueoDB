using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Mensagem
    {
        public int MensagemID { get; set; }

        [DisplayName("Utilizador Emissor")]
        public int EmissorID { get; set; }
        public virtual Utilizador Emissor { get; set; }

        [DisplayName("Utilizador Receptor")]
        public int ReceptorID { get; set; }
        public virtual Utilizador Receptor { get; set; }

        [DisplayName("Data de Envio")]
        public DateTime DataEnvio { get; set; }

        [DisplayName("Assunto da Mensagem")]
        [StringLength(200, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Assunto da mensagem necessário")]
        public string Assunto { get; set; }

        [DisplayName("Corpo da Mensagem")]
        [StringLength(5000, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Corpo da mensagem necessário")]
        public string Corpo { get; set; }

        [DisplayName("Mensagem Lida")]
        public bool Lida { get; set; }

        [ScaffoldColumn(false)]
        public bool ApagadoE { get; set; }

        [ScaffoldColumn(false)]
        public bool ApagadoR { get; set; }

    }
}