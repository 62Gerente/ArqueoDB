using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class EntidadesArqueoDB : DbContext
    {
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
    }
}