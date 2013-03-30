using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArqueoDB.Models
{
    public class EntidadesArqueoDB : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Artefacto> Artefactos { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<BadgeAtribuida> BadgesAtribuidas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<ComentarioArtefacto> ComentariosArtefactos { get; set; }
        public DbSet<ComentarioImagem> ComentariosImagens { get; set; }
        public DbSet<ComentarioLocal> ComentariosLocais { get; set; }
        public DbSet<ComentarioPublicacao> ComentariosPublicacoes { get; set; }
        public DbSet<Directoria> Directorias { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<FeedLocal> FeedsLocais { get; set; }
        public DbSet<FeedOrganizacao> FeedsOrganizacoes { get; set; }
        public DbSet<FeedUtilizador> FeedsUtilizadores { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<ImagemArtefacto> ImagensArtefactos { get; set; }
        public DbSet<ImagemLocal> ImagensLocais { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<LocalSeguido> LocaisSeguidos { get; set; }
        public DbSet<MembroOrganizacao> MembrosOrganizacoes { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Organizacao> Organizacoes { get; set; }
        public DbSet<OrganizacaoSeguida> OrganizacoesSeguidas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<PublicacaoLocal> PublicacoesLocais { get; set; }
        public DbSet<PublicacaoOrganizacao> PublicacoesOrganizacoes { get; set; }
        public DbSet<PublicacaoUtilizador> PublicacoesUtilizadores { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<UtilizadorSeguido> UtilizadoresSeguidos { get; set; }
    }
}