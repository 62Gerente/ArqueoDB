namespace ArqueoDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        AdministradorID = c.Int(nullable: false, identity: true),
                        UtilizadorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdministradorID)
                .ForeignKey("dbo.Utilizadors", t => t.UtilizadorID)
                .Index(t => t.UtilizadorID);
            
            CreateTable(
                "dbo.Utilizadors",
                c => new
                    {
                        UtilizadorID = c.Int(nullable: false, identity: true),
                        NomeUtilizador = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 30),
                        Nome = c.String(nullable: false, maxLength: 100),
                        DistritoID = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        Telemovel = c.String(maxLength: 15),
                        Facebook = c.String(maxLength: 50),
                        Google = c.String(maxLength: 50),
                        Twitter = c.String(maxLength: 50),
                        Linkedin = c.String(maxLength: 50),
                        Banido = c.Boolean(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                        DataRegisto = c.DateTime(nullable: false),
                        TituloID = c.Int(nullable: false),
                        ImagemPerfilID = c.Int(nullable: false),
                        ImagemCapaID = c.Int(nullable: false),
                        Utilizador_UtilizadorID = c.Int(),
                    })
                .PrimaryKey(t => t.UtilizadorID)
                .ForeignKey("dbo.Distritoes", t => t.DistritoID)
                .ForeignKey("dbo.Tituloes", t => t.TituloID)
                .ForeignKey("dbo.Imagems", t => t.ImagemPerfilID)
                .ForeignKey("dbo.Imagems", t => t.ImagemCapaID)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID)
                .Index(t => t.DistritoID)
                .Index(t => t.TituloID)
                .Index(t => t.ImagemPerfilID)
                .Index(t => t.ImagemCapaID)
                .Index(t => t.Utilizador_UtilizadorID);
            
            CreateTable(
                "dbo.Distritoes",
                c => new
                    {
                        DistritoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        PaisID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistritoID)
                .ForeignKey("dbo.Pais", t => t.PaisID)
                .Index(t => t.PaisID);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        PaisID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PaisID);
            
            CreateTable(
                "dbo.Locals",
                c => new
                    {
                        LocalID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        OrganizacaoID = c.Int(nullable: false),
                        ResponsavelID = c.Int(nullable: false),
                        Coordenadas = c.String(nullable: false, maxLength: 30),
                        DataRegisto = c.DateTime(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        DistritoID = c.Int(nullable: false),
                        Publico = c.Boolean(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                        Utilizador_UtilizadorID = c.Int(),
                    })
                .PrimaryKey(t => t.LocalID)
                .ForeignKey("dbo.Profissionals", t => t.ResponsavelID)
                .ForeignKey("dbo.Organizacaos", t => t.OrganizacaoID)
                .ForeignKey("dbo.Distritoes", t => t.DistritoID)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID)
                .Index(t => t.ResponsavelID)
                .Index(t => t.OrganizacaoID)
                .Index(t => t.DistritoID)
                .Index(t => t.Utilizador_UtilizadorID);
            
            CreateTable(
                "dbo.Organizacaos",
                c => new
                    {
                        OrganizacaoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Coordenadas = c.String(nullable: false, maxLength: 30),
                        Morada = c.String(maxLength: 500),
                        DistritoID = c.Int(nullable: false),
                        ResponsavelID = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        DataFundacao = c.DateTime(nullable: false),
                        Telefone = c.String(maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                        Fax = c.String(maxLength: 15),
                        ImagemPerfilID = c.Int(nullable: false),
                        ImagemCapaID = c.Int(nullable: false),
                        Publica = c.Boolean(nullable: false),
                        Activa = c.Boolean(nullable: false),
                        Apagada = c.Boolean(nullable: false),
                        Profissional_ProfissionalID = c.Int(),
                        Profissional_ProfissionalID1 = c.Int(),
                        Utilizador_UtilizadorID = c.Int(),
                    })
                .PrimaryKey(t => t.OrganizacaoID)
                .ForeignKey("dbo.Distritoes", t => t.DistritoID)
                .ForeignKey("dbo.Profissionals", t => t.Profissional_ProfissionalID)
                .ForeignKey("dbo.Profissionals", t => t.Profissional_ProfissionalID1)
                .ForeignKey("dbo.Profissionals", t => t.ResponsavelID)
                .ForeignKey("dbo.Imagems", t => t.ImagemPerfilID)
                .ForeignKey("dbo.Imagems", t => t.ImagemCapaID)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID)
                .Index(t => t.DistritoID)
                .Index(t => t.Profissional_ProfissionalID)
                .Index(t => t.Profissional_ProfissionalID1)
                .Index(t => t.ResponsavelID)
                .Index(t => t.ImagemPerfilID)
                .Index(t => t.ImagemCapaID)
                .Index(t => t.Utilizador_UtilizadorID);
            
            CreateTable(
                "dbo.Profissionals",
                c => new
                    {
                        ProfissionalID = c.Int(nullable: false, identity: true),
                        UtilizadorID = c.Int(nullable: false),
                        Organizacao_OrganizacaoID = c.Int(),
                    })
                .PrimaryKey(t => t.ProfissionalID)
                .ForeignKey("dbo.Utilizadors", t => t.UtilizadorID)
                .ForeignKey("dbo.Organizacaos", t => t.Organizacao_OrganizacaoID)
                .Index(t => t.UtilizadorID)
                .Index(t => t.Organizacao_OrganizacaoID);
            
            CreateTable(
                "dbo.Artefactoes",
                c => new
                    {
                        ArtefactoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Cordenadas = c.String(nullable: false, maxLength: 30),
                        Descricao = c.String(nullable: false, maxLength: 50),
                        DataDescoberta = c.DateTime(nullable: false),
                        LocalID = c.Int(nullable: false),
                        OrganizacaoID = c.Int(nullable: false),
                        ResponsavelID = c.Int(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                        Publico = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArtefactoID)
                .ForeignKey("dbo.Locals", t => t.LocalID)
                .ForeignKey("dbo.Organizacaos", t => t.OrganizacaoID)
                .ForeignKey("dbo.Profissionals", t => t.ResponsavelID)
                .Index(t => t.LocalID)
                .Index(t => t.OrganizacaoID)
                .Index(t => t.ResponsavelID);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ComentarioID = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 1000),
                        UtilizadorID = c.Int(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                        Artefacto_ArtefactoID = c.Int(),
                        Imagem_ImagemID = c.Int(),
                        Publicacao_PublicacaoID = c.Int(),
                        Local_LocalID = c.Int(),
                    })
                .PrimaryKey(t => t.ComentarioID)
                .ForeignKey("dbo.Utilizadors", t => t.UtilizadorID)
                .ForeignKey("dbo.Artefactoes", t => t.Artefacto_ArtefactoID)
                .ForeignKey("dbo.Imagems", t => t.Imagem_ImagemID)
                .ForeignKey("dbo.Publicacaos", t => t.Publicacao_PublicacaoID)
                .ForeignKey("dbo.Locals", t => t.Local_LocalID)
                .Index(t => t.UtilizadorID)
                .Index(t => t.Artefacto_ArtefactoID)
                .Index(t => t.Imagem_ImagemID)
                .Index(t => t.Publicacao_PublicacaoID)
                .Index(t => t.Local_LocalID);
            
            CreateTable(
                "dbo.Imagems",
                c => new
                    {
                        ImagemID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DirectoriaID = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        DataPublicacao = c.DateTime(nullable: false),
                        Publica = c.Boolean(nullable: false),
                        Apagada = c.Boolean(nullable: false),
                        Artefacto_ArtefactoID = c.Int(),
                        Local_LocalID = c.Int(),
                    })
                .PrimaryKey(t => t.ImagemID)
                .ForeignKey("dbo.Directorias", t => t.DirectoriaID)
                .ForeignKey("dbo.Artefactoes", t => t.Artefacto_ArtefactoID)
                .ForeignKey("dbo.Locals", t => t.Local_LocalID)
                .Index(t => t.DirectoriaID)
                .Index(t => t.Artefacto_ArtefactoID)
                .Index(t => t.Local_LocalID);
            
            CreateTable(
                "dbo.Directorias",
                c => new
                    {
                        DirectoriaID = c.Int(nullable: false, identity: true),
                        Caminho = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DirectoriaID);
            
            CreateTable(
                "dbo.Documentoes",
                c => new
                    {
                        DocumentoID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        DirectoriaID = c.Int(nullable: false),
                        ResponsavelID = c.Int(nullable: false),
                        OrganizacaoID = c.Int(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        Publico = c.Boolean(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentoID)
                .ForeignKey("dbo.Directorias", t => t.DirectoriaID)
                .ForeignKey("dbo.Profissionals", t => t.ResponsavelID)
                .ForeignKey("dbo.Organizacaos", t => t.OrganizacaoID)
                .Index(t => t.DirectoriaID)
                .Index(t => t.ResponsavelID)
                .Index(t => t.OrganizacaoID);
            
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        FeedID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 1000),
                        DataPublicacao = c.DateTime(nullable: false),
                        Publico = c.Boolean(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                        Organizacao_OrganizacaoID = c.Int(),
                        Local_LocalID = c.Int(),
                        Utilizador_UtilizadorID = c.Int(),
                    })
                .PrimaryKey(t => t.FeedID)
                .ForeignKey("dbo.Organizacaos", t => t.Organizacao_OrganizacaoID)
                .ForeignKey("dbo.Locals", t => t.Local_LocalID)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID)
                .Index(t => t.Organizacao_OrganizacaoID)
                .Index(t => t.Local_LocalID)
                .Index(t => t.Utilizador_UtilizadorID);
            
            CreateTable(
                "dbo.Publicacaos",
                c => new
                    {
                        PublicacaoID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        DataPublicacao = c.DateTime(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        Publico = c.Boolean(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                        Organizacao_OrganizacaoID = c.Int(),
                        Local_LocalID = c.Int(),
                        Utilizador_UtilizadorID = c.Int(),
                    })
                .PrimaryKey(t => t.PublicacaoID)
                .ForeignKey("dbo.Organizacaos", t => t.Organizacao_OrganizacaoID)
                .ForeignKey("dbo.Locals", t => t.Local_LocalID)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID)
                .Index(t => t.Organizacao_OrganizacaoID)
                .Index(t => t.Local_LocalID)
                .Index(t => t.Utilizador_UtilizadorID);
            
            CreateTable(
                "dbo.Plantas",
                c => new
                    {
                        PlantaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        LocalID = c.Int(nullable: false),
                        ImagemID = c.Int(nullable: false),
                        OrganizacaoID = c.Int(nullable: false),
                        ResponsavelID = c.Int(nullable: false),
                        DataPublicacao = c.DateTime(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        Publico = c.Boolean(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlantaID)
                .ForeignKey("dbo.Locals", t => t.LocalID)
                .ForeignKey("dbo.Imagems", t => t.ImagemID)
                .ForeignKey("dbo.Organizacaos", t => t.OrganizacaoID)
                .ForeignKey("dbo.Profissionals", t => t.ResponsavelID)
                .Index(t => t.LocalID)
                .Index(t => t.ImagemID)
                .Index(t => t.OrganizacaoID)
                .Index(t => t.ResponsavelID);
            
            CreateTable(
                "dbo.Tituloes",
                c => new
                    {
                        TituloID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.TituloID);
            
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        BadgeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DirectoriaID = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 1000),
                        Publico = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BadgeID)
                .ForeignKey("dbo.Directorias", t => t.DirectoriaID)
                .Index(t => t.DirectoriaID);
            
            CreateTable(
                "dbo.Mensagems",
                c => new
                    {
                        MensagemID = c.Int(nullable: false, identity: true),
                        EmissorID = c.Int(nullable: false),
                        ReceptorID = c.Int(nullable: false),
                        DataEnvio = c.DateTime(nullable: false),
                        Assunto = c.String(nullable: false, maxLength: 200),
                        Corpo = c.String(nullable: false),
                        Lida = c.Boolean(nullable: false),
                        ApagadoE = c.Boolean(nullable: false),
                        ApagadoR = c.Boolean(nullable: false),
                        Utilizador_UtilizadorID = c.Int(),
                        Utilizador_UtilizadorID1 = c.Int(),
                    })
                .PrimaryKey(t => t.MensagemID)
                .ForeignKey("dbo.Utilizadors", t => t.EmissorID)
                .ForeignKey("dbo.Utilizadors", t => t.ReceptorID)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID1)
                .Index(t => t.EmissorID)
                .Index(t => t.ReceptorID)
                .Index(t => t.Utilizador_UtilizadorID)
                .Index(t => t.Utilizador_UtilizadorID1);
            
            CreateTable(
                "dbo.BadgeUtilizadors",
                c => new
                    {
                        Badge_BadgeID = c.Int(nullable: false),
                        Utilizador_UtilizadorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Badge_BadgeID, t.Utilizador_UtilizadorID })
                .ForeignKey("dbo.Badges", t => t.Badge_BadgeID, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadors", t => t.Utilizador_UtilizadorID, cascadeDelete: true)
                .Index(t => t.Badge_BadgeID)
                .Index(t => t.Utilizador_UtilizadorID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BadgeUtilizadors", new[] { "Utilizador_UtilizadorID" });
            DropIndex("dbo.BadgeUtilizadors", new[] { "Badge_BadgeID" });
            DropIndex("dbo.Mensagems", new[] { "Utilizador_UtilizadorID1" });
            DropIndex("dbo.Mensagems", new[] { "Utilizador_UtilizadorID" });
            DropIndex("dbo.Mensagems", new[] { "ReceptorID" });
            DropIndex("dbo.Mensagems", new[] { "EmissorID" });
            DropIndex("dbo.Badges", new[] { "DirectoriaID" });
            DropIndex("dbo.Plantas", new[] { "ResponsavelID" });
            DropIndex("dbo.Plantas", new[] { "OrganizacaoID" });
            DropIndex("dbo.Plantas", new[] { "ImagemID" });
            DropIndex("dbo.Plantas", new[] { "LocalID" });
            DropIndex("dbo.Publicacaos", new[] { "Utilizador_UtilizadorID" });
            DropIndex("dbo.Publicacaos", new[] { "Local_LocalID" });
            DropIndex("dbo.Publicacaos", new[] { "Organizacao_OrganizacaoID" });
            DropIndex("dbo.Feeds", new[] { "Utilizador_UtilizadorID" });
            DropIndex("dbo.Feeds", new[] { "Local_LocalID" });
            DropIndex("dbo.Feeds", new[] { "Organizacao_OrganizacaoID" });
            DropIndex("dbo.Documentoes", new[] { "OrganizacaoID" });
            DropIndex("dbo.Documentoes", new[] { "ResponsavelID" });
            DropIndex("dbo.Documentoes", new[] { "DirectoriaID" });
            DropIndex("dbo.Imagems", new[] { "Local_LocalID" });
            DropIndex("dbo.Imagems", new[] { "Artefacto_ArtefactoID" });
            DropIndex("dbo.Imagems", new[] { "DirectoriaID" });
            DropIndex("dbo.Comentarios", new[] { "Local_LocalID" });
            DropIndex("dbo.Comentarios", new[] { "Publicacao_PublicacaoID" });
            DropIndex("dbo.Comentarios", new[] { "Imagem_ImagemID" });
            DropIndex("dbo.Comentarios", new[] { "Artefacto_ArtefactoID" });
            DropIndex("dbo.Comentarios", new[] { "UtilizadorID" });
            DropIndex("dbo.Artefactoes", new[] { "ResponsavelID" });
            DropIndex("dbo.Artefactoes", new[] { "OrganizacaoID" });
            DropIndex("dbo.Artefactoes", new[] { "LocalID" });
            DropIndex("dbo.Profissionals", new[] { "Organizacao_OrganizacaoID" });
            DropIndex("dbo.Profissionals", new[] { "UtilizadorID" });
            DropIndex("dbo.Organizacaos", new[] { "Utilizador_UtilizadorID" });
            DropIndex("dbo.Organizacaos", new[] { "ImagemCapaID" });
            DropIndex("dbo.Organizacaos", new[] { "ImagemPerfilID" });
            DropIndex("dbo.Organizacaos", new[] { "ResponsavelID" });
            DropIndex("dbo.Organizacaos", new[] { "Profissional_ProfissionalID1" });
            DropIndex("dbo.Organizacaos", new[] { "Profissional_ProfissionalID" });
            DropIndex("dbo.Organizacaos", new[] { "DistritoID" });
            DropIndex("dbo.Locals", new[] { "Utilizador_UtilizadorID" });
            DropIndex("dbo.Locals", new[] { "DistritoID" });
            DropIndex("dbo.Locals", new[] { "OrganizacaoID" });
            DropIndex("dbo.Locals", new[] { "ResponsavelID" });
            DropIndex("dbo.Distritoes", new[] { "PaisID" });
            DropIndex("dbo.Utilizadors", new[] { "Utilizador_UtilizadorID" });
            DropIndex("dbo.Utilizadors", new[] { "ImagemCapaID" });
            DropIndex("dbo.Utilizadors", new[] { "ImagemPerfilID" });
            DropIndex("dbo.Utilizadors", new[] { "TituloID" });
            DropIndex("dbo.Utilizadors", new[] { "DistritoID" });
            DropIndex("dbo.Administradors", new[] { "UtilizadorID" });
            DropForeignKey("dbo.BadgeUtilizadors", "Utilizador_UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.BadgeUtilizadors", "Badge_BadgeID", "dbo.Badges");
            DropForeignKey("dbo.Mensagems", "Utilizador_UtilizadorID1", "dbo.Utilizadors");
            DropForeignKey("dbo.Mensagems", "Utilizador_UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Mensagems", "ReceptorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Mensagems", "EmissorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Badges", "DirectoriaID", "dbo.Directorias");
            DropForeignKey("dbo.Plantas", "ResponsavelID", "dbo.Profissionals");
            DropForeignKey("dbo.Plantas", "OrganizacaoID", "dbo.Organizacaos");
            DropForeignKey("dbo.Plantas", "ImagemID", "dbo.Imagems");
            DropForeignKey("dbo.Plantas", "LocalID", "dbo.Locals");
            DropForeignKey("dbo.Publicacaos", "Utilizador_UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Publicacaos", "Local_LocalID", "dbo.Locals");
            DropForeignKey("dbo.Publicacaos", "Organizacao_OrganizacaoID", "dbo.Organizacaos");
            DropForeignKey("dbo.Feeds", "Utilizador_UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Feeds", "Local_LocalID", "dbo.Locals");
            DropForeignKey("dbo.Feeds", "Organizacao_OrganizacaoID", "dbo.Organizacaos");
            DropForeignKey("dbo.Documentoes", "OrganizacaoID", "dbo.Organizacaos");
            DropForeignKey("dbo.Documentoes", "ResponsavelID", "dbo.Profissionals");
            DropForeignKey("dbo.Documentoes", "DirectoriaID", "dbo.Directorias");
            DropForeignKey("dbo.Imagems", "Local_LocalID", "dbo.Locals");
            DropForeignKey("dbo.Imagems", "Artefacto_ArtefactoID", "dbo.Artefactoes");
            DropForeignKey("dbo.Imagems", "DirectoriaID", "dbo.Directorias");
            DropForeignKey("dbo.Comentarios", "Local_LocalID", "dbo.Locals");
            DropForeignKey("dbo.Comentarios", "Publicacao_PublicacaoID", "dbo.Publicacaos");
            DropForeignKey("dbo.Comentarios", "Imagem_ImagemID", "dbo.Imagems");
            DropForeignKey("dbo.Comentarios", "Artefacto_ArtefactoID", "dbo.Artefactoes");
            DropForeignKey("dbo.Comentarios", "UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Artefactoes", "ResponsavelID", "dbo.Profissionals");
            DropForeignKey("dbo.Artefactoes", "OrganizacaoID", "dbo.Organizacaos");
            DropForeignKey("dbo.Artefactoes", "LocalID", "dbo.Locals");
            DropForeignKey("dbo.Profissionals", "Organizacao_OrganizacaoID", "dbo.Organizacaos");
            DropForeignKey("dbo.Profissionals", "UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Organizacaos", "Utilizador_UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Organizacaos", "ImagemCapaID", "dbo.Imagems");
            DropForeignKey("dbo.Organizacaos", "ImagemPerfilID", "dbo.Imagems");
            DropForeignKey("dbo.Organizacaos", "ResponsavelID", "dbo.Profissionals");
            DropForeignKey("dbo.Organizacaos", "Profissional_ProfissionalID1", "dbo.Profissionals");
            DropForeignKey("dbo.Organizacaos", "Profissional_ProfissionalID", "dbo.Profissionals");
            DropForeignKey("dbo.Organizacaos", "DistritoID", "dbo.Distritoes");
            DropForeignKey("dbo.Locals", "Utilizador_UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Locals", "DistritoID", "dbo.Distritoes");
            DropForeignKey("dbo.Locals", "OrganizacaoID", "dbo.Organizacaos");
            DropForeignKey("dbo.Locals", "ResponsavelID", "dbo.Profissionals");
            DropForeignKey("dbo.Distritoes", "PaisID", "dbo.Pais");
            DropForeignKey("dbo.Utilizadors", "Utilizador_UtilizadorID", "dbo.Utilizadors");
            DropForeignKey("dbo.Utilizadors", "ImagemCapaID", "dbo.Imagems");
            DropForeignKey("dbo.Utilizadors", "ImagemPerfilID", "dbo.Imagems");
            DropForeignKey("dbo.Utilizadors", "TituloID", "dbo.Tituloes");
            DropForeignKey("dbo.Utilizadors", "DistritoID", "dbo.Distritoes");
            DropForeignKey("dbo.Administradors", "UtilizadorID", "dbo.Utilizadors");
            DropTable("dbo.BadgeUtilizadors");
            DropTable("dbo.Mensagems");
            DropTable("dbo.Badges");
            DropTable("dbo.Tituloes");
            DropTable("dbo.Plantas");
            DropTable("dbo.Publicacaos");
            DropTable("dbo.Feeds");
            DropTable("dbo.Documentoes");
            DropTable("dbo.Directorias");
            DropTable("dbo.Imagems");
            DropTable("dbo.Comentarios");
            DropTable("dbo.Artefactoes");
            DropTable("dbo.Profissionals");
            DropTable("dbo.Organizacaos");
            DropTable("dbo.Locals");
            DropTable("dbo.Pais");
            DropTable("dbo.Distritoes");
            DropTable("dbo.Utilizadors");
            DropTable("dbo.Administradors");
        }
    }
}
