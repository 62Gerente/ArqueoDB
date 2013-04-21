using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class Badge
    {
        public int BadgeID { get; set; }

        [DisplayName("Nome da Badge")]
        [StringLength(50, ErrorMessage = "Número máximo de caracteres excedido")]
        [Required(ErrorMessage = "Nome da badge necessário")]
        public string Nome { get; set; }

        [DisplayName("Directoria")]
        public int DirectoriaID { get; set; }
        public virtual Directoria Directoria { get; set; }

        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "Número máximo de caracteres excedido")]
        public string Descricao { get; set; }

        [DisplayName("Activa")]
        public bool Publico { get; set; } 

        public virtual ICollection<Utilizador> Utilizadores { get; set; }

    }
}