namespace ArqueoDB.Migrations
{
    using ArqueoDB.Models;
    using ArqueoDB.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArqueoDB.DAL.EntidadesArqueoDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntidadesArqueoDB context)
        {            
            var titulos = new List<Titulo>
            {
                new Titulo{Nome = "Senhor(a) Engenheiro"},
                new Titulo{Nome = "Senhor(a)"}
            };
            titulos.ForEach(t => context.Titulos.Add(t));
            context.SaveChanges();

            var directorias = new List<Directoria>
            {
                new Directoria{Caminho = "/Images/Organizacoes/"},
                new Directoria{Caminho = "/Images/Utilizadores/"},
                new Directoria{Caminho = "/Images/Locais/"},
                new Directoria{Caminho = "/Imagens/Artefactos/"},
                new Directoria{Caminho = "/Documentos/"}
            };
            directorias.ForEach(d => context.Directorias.Add(d));
            context.SaveChanges();

            var imagens = new List<Imagem>
            {
                new Imagem{
                    Nome = "um.jpg", 
                    DirectoriaID = 1, 
                    Descricao = "Imagem perfil UM", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "um60.jpeg", 
                    DirectoriaID = 1, 
                    Descricao = "Imagem capa UM", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "mddiogo.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Imagem Museu", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "teatro.jpg", 
                    DirectoriaID = 3, 
                    Descricao = "Imagem Teatro UM", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "jonas.jpg", 
                    DirectoriaID = 2, 
                    Descricao = "Jonas lindo!", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "barney.png", 
                    DirectoriaID = 2, 
                    Descricao = "Barney Stinson!", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "robin.jpg", 
                    DirectoriaID = 2, 
                    Descricao = "A robin!", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                },
                new Imagem{
                    Nome = "estelafuneraria.jpg", 
                    DirectoriaID = 4, 
                    Descricao = "Estela", 
                    Apagada = false, 
                    Publica = true,
                    DataPublicacao = System.DateTime.Now
                }
            };
            imagens.ForEach(i => context.Imagens.Add(i));
            context.SaveChanges();

            var paises = new List<Pais>
            {
                new Pais{
                    Nome = "Portugal", 
                    Distritos = new List<Distrito>()
                }
            };
            paises.ForEach(p => context.Paises.Add(p));
            context.SaveChanges();

            var distritos = new List<Distrito>
            {
                new Distrito{
                    Nome = "Braga", 
                    PaisID = 1, 
                    Utilizadores = new List<Utilizador>(),
                    Organizacoes = new List<Organizacao>(),
                    Locais = new List<Local>()
                }
            };
            distritos.ForEach(d => context.Distritos.Add(d));
            context.SaveChanges();

            paises[0].Distritos.Add(distritos[0]);
            context.SaveChanges();

            var utilizadores = new List<Utilizador>
            {
                new Utilizador{
                    NomeUtilizador = "Jonas",
                    Nome = "Jonas Pinto",
                    Password = "papatesaluto",
                    Apagado = false,
                    Banido = false,
                    DataNascimento = System.DateTime.Now,
                    DataRegisto = System.DateTime.Now,
                    Descricao = "Admite lá esse cansaço",
                    Email = "jonas@cabidocardeais.com",
                    DistritoID = 1,
                    ImagemCapaID = 4,
                    ImagemPerfilID = 5,
                    Sexo = 1,
                    TituloID = 2
                },
                new Utilizador{
                    NomeUtilizador = "Barney",
                    Nome = "Barney Stinson",
                    Password = "playbook",
                    Apagado = false,
                    Banido = false,
                    DataNascimento = System.DateTime.Now,
                    DataRegisto = System.DateTime.Now,
                    Descricao = "Fácil",
                    Email = "barney@hymym.com",
                    DistritoID = 1,
                    ImagemCapaID = 4,
                    ImagemPerfilID = 6,
                    Sexo = 1,
                    TituloID = 2
                },
                new Utilizador{
                    NomeUtilizador = "Robin",
                    Nome = "Robin Scherbatsky",
                    Password = "single",
                    Apagado = false,
                    Banido = false,
                    DataNascimento = System.DateTime.Now,
                    DataRegisto = System.DateTime.Now,
                    Descricao = "buthum",
                    Email = "robin@hymym.com",
                    DistritoID = 1,
                    ImagemCapaID = 4,
                    ImagemPerfilID = 7,
                    Sexo = 2,
                    TituloID = 2
                }
            };
            utilizadores.ForEach(u => context.Utilizadores.Add(u));
            context.SaveChanges();

            distritos[0].Utilizadores.Add(utilizadores[0]);
            context.SaveChanges();

            var profissionais = new List<Profissional>
            {
                new Profissional{UtilizadorID = 1},
                new Profissional{UtilizadorID = 2},
                new Profissional{UtilizadorID = 3}
            };
            profissionais.ForEach(p => context.Profissionais.Add(p));
            context.SaveChanges();

            var organizacoes = new List<Organizacao>
            {
                new Organizacao{
                    Nome = "Universidade do Minho",
                    Activa = true, 
                    Apagada = false,
                    Coordenadas = "30-60-20",
                    DataFundacao = System.DateTime.Now,
                    Descricao = "A Universidade do Minho (UM) foi fundada em Braga em 1973 e integrou-se no chamado grupo das Novas Universidades que vieram alterar o panorama do ensino superior em Portugal. Iniciou as suas actividades académicas em 1975/76.",
                    DistritoID = 1,
                    Email = "um@um.pt",
                    ImagemCapaID = 2,
                    ImagemPerfilID = 1,
                    Morada = "Rua Nova Santa Cruz",
                    ResponsavelID = 1,
                    Publica = true,
                    Membros = new List<Profissional>(),
                    Locais = new List<Local>(),
                    Documentos = new List<Documento>()
                }
            };
            organizacoes.ForEach(o => context.Organizacoes.Add(o));
            context.SaveChanges();

            distritos[0].Organizacoes.Add(organizacoes[0]);
            context.SaveChanges();

            organizacoes[0].Membros.Add(profissionais[0]);
            organizacoes[0].Membros.Add(profissionais[1]);
            organizacoes[0].Membros.Add(profissionais[2]);
            context.SaveChanges();

            var locais = new List<Local>
            {
                new Local{
                    Nome = "Museu D. Diogo de Sousa",
                    DistritoID = 1,
                    ResponsavelID = 1,
                    OrganizacaoID = 1,
                    Apagado = false,
                    Coordenadas = "30-30-50",
                    DataRegisto = System.DateTime.Now,
                    Descricao = "O Museu de Arqueologia D. Diogo de Sousa é um organismo público, dependente da Direção Regional de Cultura do Norte definido na sua Lei orgânica como um museu regional de arqueologia.",
                    Publico = true,
                    Imagens = new List<Imagem>(),
                    Artefactos = new List<Artefacto>(),
                    Documentos = new List<Documento>()
                },
                new Local{
                    Nome = "Teatro Romano",
                    DistritoID = 1,
                    ResponsavelID = 1,
                    OrganizacaoID = 1,
                    Apagado = false,
                    Coordenadas = "50-90-10",
                    DataRegisto = System.DateTime.Now,
                    Descricao = "O Teatro romano do Alto da Cividade, em Braga, é o único teatro romano existente no noroeste da Península Ibérica (e o único também que está a ser escavado actualmente em Portugal e Espanha) fica situado junto às Termas romanas de Maximinos, em Braga.",
                    Publico = true,
                    Imagens = new List<Imagem>(),
                    Artefactos = new List<Artefacto>(),
                    Documentos = new List<Documento>()
                },
            };
            locais.ForEach(l => context.Locais.Add(l));
            context.SaveChanges();

            distritos[0].Locais.Add(locais[0]);
            distritos[0].Locais.Add(locais[1]);
            context.SaveChanges();

            organizacoes[0].Locais.Add(locais[0]);
            organizacoes[0].Locais.Add(locais[1]);
            context.SaveChanges();

            locais[0].Imagens.Add(imagens[2]);
            locais[1].Imagens.Add(imagens[3]);
            context.SaveChanges();

            var artefactos = new List<Artefacto>
            {
                new Artefacto{
                    Nome = "Estela Funerária III D.C.",
                    Apagado = false,
                    Cordenadas = "20-20-22",
                    DataDescoberta = System.DateTime.Now,
                    Descricao = "Estela de granito, truncada na parte superior e inferior e incompleta no lado esquerdo. A parte superior denota traços de uma decoração feita de uma rosácea circundada por um cordão entrançado.",
                    Imagens = new List<Imagem>(),
                    LocalID = 1,
                    OrganizacaoID = 1,
                    Publico = true,
                    ResponsavelID = 1
                }
            };
            artefactos.ForEach(a => context.Artefactos.Add(a));
            context.SaveChanges();

            locais[0].Artefactos.Add(artefactos[0]);
            context.SaveChanges();

            artefactos[0].Imagens.Add(imagens[7]);
            context.SaveChanges();

            var documentos = new List<Documento>
            {
                new Documento{
                    Titulo = "The Playbook",                
                    NomeFicheiro = "playbook.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 2,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "Peace and love!",                    
                    Publico = true,        
                    Apagado = false
                },
                new Documento{
                    Titulo = "A obra do mestre André",                
                    NomeFicheiro = "mestre_andre.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 3,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "Fantástico!",                    
                    Publico = false,        
                    Apagado = false
                },
                new Documento{
                    Titulo = "Harry Poter",                
                    NomeFicheiro = "documento.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 3,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "A versão de hp da robin",                    
                    Publico = true,        
                    Apagado = false
                },
                new Documento{
                    Titulo = "Jonas, Quando for grande quero ser como tu!",                
                    NomeFicheiro = "documento.pdf",
                    DirectoriaID = 5,       
                    ResponsavelID = 1,            
                    OrganizacaoID = 1,        
                    DataPublicacao = System.DateTime.Now,        
                    Descricao = "Não há palavras",                    
                    Publico = false,        
                    Apagado = false
                }
            };         

            documentos.ForEach(d => context.Documentos.Add(d));            
            context.SaveChanges();

            organizacoes[0].Documentos.Add(documentos[0]);
            organizacoes[0].Documentos.Add(documentos[1]);
            context.SaveChanges();

            documentos.ForEach(d => locais[0].Documentos.Add(d));            
            context.SaveChanges();
        }
    }
}

