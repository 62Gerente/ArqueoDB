using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ArqueoDB.Models;

namespace ArqueoDB.DAL
{
    public class EntidadesArqueoDB : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Artefacto> Artefactos { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Directoria> Directorias { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        modelBuilder.Entity<Profissional>()
            .HasMany<Organizacao>(x => x.Organizacoes)
            .WithMany(x => x.Membros)
            .Map(x =>
            {
                x.MapLeftKey("ProfissionalID");
                x.MapRightKey("OrganizacaoID");
            });

        modelBuilder.Entity<Utilizador>()
            .HasMany<Utilizador>(x => x.UtilizadoresSeguidos)
            .WithMany(x => x.Seguidores)
            .Map(x =>
            {
                x.MapLeftKey("SeguidorID");
                x.MapRightKey("SeguidoID");
            });

        modelBuilder.Entity<Utilizador>()
            .HasMany<Organizacao>(x => x.OrganizacoesSeguidas)
            .WithMany(x => x.Seguidores)
            .Map(x =>
            {
                x.MapLeftKey("SeguidorID");
                x.MapRightKey("SeguidaID");
            });

        }
    }
}