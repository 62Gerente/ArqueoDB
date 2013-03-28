using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string NomeUtilizador { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public bool Sexo { get; set; }
        public string Descricao { get; set; }
        public string Telemovel { get; set; }
        public string Facebook { get; set; }
        public string Google { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public bool Banido { get; set; }
        public bool Apagado { get; set; }

        [DisplayName("Título")]
        public int TituloID { get; set; }

        public virtual Titulo Titulo { get; set; }
    }
}